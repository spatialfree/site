$(document).ready(function () {
  var nav = `<div style="display: flex; justify-content: space-between; align-items: center; border-bottom: 2px solid #666; background: gray;">`
  nav += `<a href="/">` // javascript:javascript:history.go(-1)
  nav += `<img src="/res/icons/home-icon.svg" style="margin: 1rem; width: 32px; height: 32px;" />`
  nav += `</a>`
  nav += `</div>`

  $('#nav').html(nav);
  $('#footer').html('&copy; 2022 Ethan Merchant');
  $('.project-vid').each(function () {
    $(this).on('loadeddata', function() {
      var duration = $(this).prop('duration')
      var t = Math.random() * duration
      $(this).prop('currentTime', t)
    })
  })

  $('.project-vid').trigger('pause')
  // $('.project-vid').mouseenter(function() {
  //   // console.log('mouseenter')
  //   $(this).trigger('play')
  //   // position
  //   console.log($(this).offset())
  //   // scroll pos
  //   console.log($(window).scrollTop())


  // }).mouseleave(function () {
  //   // console.log('mouseleave')
  //   $(this).trigger('pause')
  
  //   // $(this).prop('volume', 0)
  //   // $(this).css('border', 'none')
  // })

  // on scroll
  $(window).scroll(function () { 
    // viewport height
    let scrollPos = $(window).scrollTop() + (window.innerHeight / 2)
    $('#scroller').css('top', scrollPos + 'px')
    $('.project-vid').each(function () {
      $(this).trigger('pause')
      $(this).next().css('box-shadow', 'inset 0px 0px 0px 4px #cccccc00')
      
      if (scrollPos > $(this).offset().top && scrollPos < $(this).offset().top + $(this).height()) {
        $(this).trigger('play')
        $(this).next().css('box-shadow', 'inset 0px 0px 0px 4px #ccc')
      }
    })
  })
})
