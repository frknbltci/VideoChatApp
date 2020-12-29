﻿/*
 * Responsee JS - v4.1 - 2017-05-14
 * https://www.myresponsee.com
 * Copyright 2016, Vision Design - graphic zoo
 * Free to use under the MIT license.
*/
jQuery(document).ready(function($) {
  //Responsee tabs
  $('.tabs').each(function(intex, element) {
      current_tabs = $(this);
      $(this).prepend('<div class="tab-nav line"></div>');
      var tab_buttons = $(element).find('.tab-label');
      $(this).children('.tab-nav').prepend(tab_buttons);
      $(this).children('.tab-item').each(function(i) {
          $(this).attr("id", "tab-" + (i + 1));
      });
      $(".tab-nav").each(function() {
          $(this).children().each(function(i) {
              $(this).attr("href", "#tab-" + (i + 1));
          });
      });
      $(this).find(".tab-nav a").click(function(event) {
          $(this).parent().children().removeClass("active-btn");
          $(this).addClass("active-btn");
          var tab = $(this).attr("href");
          $(this).parent().parent().find(".tab-item").not(tab).css("display", "none");
          $(this).parent().parent().find(tab).fadeIn();
          return false;
      });
  });
  //Responsee eside nav
  $('.aside-nav > ul > li ul').each(function(index, element) {
    var count = $(element).find('li').length;
    var content = '<span class="count-number"> ' + count + '</span>';
    $(element).closest('li').children('a').append(content);
  });
  $('.aside-nav > ul > li:has(ul)').addClass('aside-submenu');
  $('.aside-nav > ul ul > li:has(ul)').addClass('aside-sub-submenu'); 
    $('.aside-nav > ul > li.aside-submenu > a').attr('aria-haspopup', 'true').click(function() {
    //Close other open sub menus
    $('.aside-nav ul li.aside-submenu:not(:hover) > ul').removeClass('show-aside-ul', 'slow');
    $('.aside-nav ul li.aside-submenu:hover > ul').toggleClass('show-aside-ul', 'slow'); 
  }); 
  $('.aside-nav > ul ul > li.aside-sub-submenu > a').attr('aria-haspopup', 'true').click(function() { 
    //Close other open sub menus
    $('.aside-nav ul ul li:not(:hover) > ul').removeClass('show-aside-ul', 'slow');
    $('.aside-nav ul ul li:hover > ul').toggleClass('show-aside-ul', 'slow');
  });
  //Mobile aside navigation
  $('.aside-nav-text').each(function(index, element) {
    $(element).click(function() { 
      $('.aside-nav > ul').toggleClass('show-menu', 'slow');
    });
  });  
  //Responsee nav   
  $('.top-nav > ul > li ul').each(function(index, element) {
    var count = $(element).find('li').length;
    var content = '<span class="count-number"> ' + count + '</span>';
    $(element).closest('li').children('a').append(content);
  });
  $('.top-nav > ul li:has(ul)').addClass('submenu');
  $('.top-nav > ul ul li:has(ul)').addClass('sub-submenu').removeClass('submenu');
  $('.top-nav > ul li.submenu > a').attr('aria-haspopup', 'true').click(function() { 
    //Close other open sub menus
    $('.top-nav > ul li.submenu > ul').removeClass('show-ul', 'slow'); 
    $('.top-nav > ul li.submenu:hover > ul').toggleClass('show-ul', 'slow');
  }); 
  $('.top-nav > ul ul > li.sub-submenu > a').attr('aria-haspopup', 'true').click(function() {  
    //Close other open sub menus
    $('.top-nav ul ul li > ul').removeClass('show-ul', 'slow');  
    $('.top-nav ul ul li:hover > ul').toggleClass('show-ul', 'slow');   
  });
  //Mobile aside navigation  
  $('.nav-text').click(function() { 
    $('.top-nav > ul').toggleClass('show-menu', 'slow');
  }); 
  //Custom forms
  $(function() {
    var input = document.createElement("input");
    if (('placeholder' in input) == false) {
      $('[placeholder]').focus(function() {
        var i = $(this);
        if (i.val() == i.attr('placeholder')) {
          i.val('').removeClass('placeholder');
          if (i.hasClass('password')) {
            i.removeClass('password');
            this.type = 'password';
          }
        }
      }).blur(function() {
        var i = $(this);
        if (i.val() == '' || i.val() == i.attr('placeholder')) {
          if (this.type == 'password') {
            i.addClass('password');
            this.type = 'text';
          }
          i.addClass('placeholder').val(i.attr('placeholder'));
        }
      }).blur().parents('form').submit(function() {
        $(this).find('[placeholder]').each(function() {
          var i = $(this);
          if (i.val() == i.attr('placeholder')) i.val('');
        })
      });
    }
  });
  //Tooltip
  $(".tooltip-container").each(function () {
    $(this).hover(function(){  
      var pos = $(this).position();  
      var container = $(this);
      var pos = container.offset();
      tip = $(this).find('.tooltip-content');
      tip_top = $(this).find('.tooltip-content.tooltip-top');
      tip_bottom = $(this).find('.tooltip-content.tooltip-bottom');
      
      var height = tip.height();
      tip.fadeIn("fast"); //Show tooltip
      tip_top.css({
        top: pos.top - height,
        left: pos.left + (container.width() /2) - (tip.outerWidth(true)/2)
      })
      tip_bottom.css({
        top: pos.top,
        left: pos.left + (container.width() /2) - (tip.outerWidth(true)/2)
      })
      }, function() {
          tip.fadeOut("fast"); //Hide tooltip
    });
  });
  //Active item
  var url = window.location.href;
  $('a').filter(function() {
    return this.href == url;
  }).parent('li').addClass('active-item');
  var url = window.location.href;
  $('.aside-nav a').filter(function() {
    return this.href == url;
  }).parent('li').parent('ul').addClass('active-aside-item');
  var url = window.location.href;
  $('.aside-nav a').filter(function() {
    return this.href == url;
  }).parent('li').parent('ul').parent('li').parent('ul').addClass('active-aside-item');
  var url = window.location.href;
  $('.aside-nav a').filter(function() {
    return this.href == url;
  }).parent('li').parent('ul').parent('li').parent('ul').parent('li').parent('ul').addClass('active-aside-item');
});