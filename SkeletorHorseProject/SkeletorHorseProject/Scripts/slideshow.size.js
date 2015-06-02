﻿

resizeableImage($('.resize-image'));


var resizeableImage = function(image_target) {

    // ...
    init = function(){

        // Create a new image with a copy of the original src
        // When resizing, we will always use this original copy as the base
        orig_src.src=image_target.src;

        // Add resize handles
        $(image_target).wrap('<div class="resize-container"></div>')
        .before('<span class="resize-handle resize-handle-nw"></span>')
        .before('<span class="resize-handle resize-handle-ne"></span>')
        .after('<span class="resize-handle resize-handle-se"></span>')
        .after('<span class="resize-handle resize-handle-sw"></span>');

        // Get a variable for the container
        $container =  $(image_target).parent('.resize-container');

        // Add events
        $container.on('mousedown', '.resize-handle', startResize);
    };

    //...

    init();
}

startResize = function(e){
    e.preventDefault();
    e.stopPropagation();
    saveEventState(e);
    $(document).on('mousemove', resizing);
    $(document).on('mouseup', endResize);
};

endResize = function(e){
    e.preventDefault();
    $(document).off('mouseup touchend', endResize);
    $(document).off('mousemove touchmove', resizing);
};

saveEventState = function(e){
    // Save the initial event details and container state
    event_state.container_width = $container.width();
    event_state.container_height = $container.height();
    event_state.container_left = $container.offset().left; 
    event_state.container_top = $container.offset().top;
    event_state.mouse_x = (e.clientX || e.pageX || e.originalEvent.touches[0].clientX) + $(window).scrollLeft(); 
    event_state.mouse_y = (e.clientY || e.pageY || e.originalEvent.touches[0].clientY) + $(window).scrollTop();

    // This is a fix for mobile safari
    // For some reason it does not allow a direct copy of the touches property
    if(typeof e.originalEvent.touches !== 'undefined'){
        event_state.touches = [];
        $.each(e.originalEvent.touches, function(i, ob){
            event_state.touches[i] = {};
            event_state.touches[i].clientX = 0+ob.clientX;
            event_state.touches[i].clientY = 0+ob.clientY;
        });
    }
    event_state.evnt = e;
}

resizing = function(e){ 
    var mouse={},width,height,left,top,offset=$container.offset();
    mouse.x = (e.clientX || e.pageX || e.originalEvent.touches[0].clientX) + $(window).scrollLeft(); 
    mouse.y = (e.clientY || e.pageY || e.originalEvent.touches[0].clientY) + $(window).scrollTop();

    width = mouse.x - event_state.container_left;
    height = mouse.y  - event_state.container_top;
    left = event_state.container_left;
    top = event_state.container_top;

    if(constrain || e.shiftKey){
        height = width / orig_src.width * orig_src.height;
    }

    if(width > min_width && height > min_height && width < max_width && height < max_height){
        resizeImage(width, height);  
        // Without this Firefox will not re-calculate the the image dimensions until drag end
        $container.offset({'left': left, 'top': top});        
    }
}

resizeImage = function(width, height){
    resize_canvas.width = width;
    resize_canvas.height = height;
    resize_canvas.getContext('2d').drawImage(orig_src, 0, 0, width, height);   
    $(image_target).attr('src', resize_canvas.toDataURL("image/png"));  
};

resizing = function(e){
    var mouse={},width,height,left,top,offset=$container.offset();
    mouse.x = (e.clientX || e.pageX || e.originalEvent.touches[0].clientX) + $(window).scrollLeft(); 
    mouse.y = (e.clientY || e.pageY || e.originalEvent.touches[0].clientY) + $(window).scrollTop();
  
    // Position image differently depending on the corner dragged and constraints
    if( $(event_state.evnt.target).hasClass('resize-handle-se') ){
        width = mouse.x - event_state.container_left;
        height = mouse.y  - event_state.container_top;
        left = event_state.container_left;
        top = event_state.container_top;
    } else if($(event_state.evnt.target).hasClass('resize-handle-sw') ){
        width = event_state.container_width - (mouse.x - event_state.container_left);
        height = mouse.y  - event_state.container_top;
        left = mouse.x;
        top = event_state.container_top;
    } else if($(event_state.evnt.target).hasClass('resize-handle-nw') ){
        width = event_state.container_width - (mouse.x - event_state.container_left);
        height = event_state.container_height - (mouse.y - event_state.container_top);
        left = mouse.x;
        top = mouse.y;
        if(constrain || e.shiftKey){
            top = mouse.y - ((width / orig_src.width * orig_src.height) - height);
        }
    } else if($(event_state.evnt.target).hasClass('resize-handle-ne') ){
        width = mouse.x - event_state.container_left;
        height = event_state.container_height - (mouse.y - event_state.container_top);
        left = event_state.container_left;
        top = mouse.y;
        if(constrain || e.shiftKey){
            top = mouse.y - ((width / orig_src.width * orig_src.height) - height);
        }
    }

    // Optionally maintain aspect ratio
    if(constrain || e.shiftKey){
        height = width / orig_src.width * orig_src.height;
    }

    if(width > min_width && height > min_height && width < max_width && height < max_height){
        // To improve performance you might limit how often resizeImage() is called
        resizeImage(width, height);  
        // Without this Firefox will not re-calculate the the image dimensions until drag end
        $container.offset({'left': left, 'top': top});
    }
}

init = function () {

    //...

    $('.js-crop').on('click', crop);

};

crop = function () {
    var crop_canvas,
        left = $('.overlay').offset().left - $container.offset().left,
        top = $('.overlay').offset().top - $container.offset().top,
        width = $('.overlay').width(),
        height = $('.overlay').height();

    crop_canvas = document.createElement('canvas');
    crop_canvas.width = width;
    crop_canvas.height = height;

    crop_canvas.getContext('2d').drawImage(image_target, left, top, width, height, 0, 0, width, height);
    window.open(crop_canvas.toDataURL("image/png"));
}