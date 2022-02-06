$(document).ready(function () {
  var nav = `<div style="display: flex; justify-content: space-between; align-items: center; border-bottom: 2px solid white; background: gray;">`
  nav += `<a href="/">`
  nav += `<div class="home"></div>`
  // nav += `<img src="/favicon/favicon-32x32.png" width="32px" style="margin: 1rem">`
  nav += `</a>`
  // nav += `<svg viewBox="0 0 576 512" class="svg-inline" style="height: 64px;"><path fill="currentColor" d="M280.37 148.26L96 300.11V464a16 16 0 0 0 16 16l112.06-.29a16 16 0 0 0 15.92-16V368a16 16 0 0 1 16-16h64a16 16 0 0 1 16 16v95.64a16 16 0 0 0 16 16.05L464 480a16 16 0 0 0 16-16V300L295.67 148.26a12.19 12.19 0 0 0-15.3 0zM571.6 251.47L488 182.56V44.05a12 12 0 0 0-12-12h-56a12 12 0 0 0-12 12v72.61L318.47 43a48 48 0 0 0-61 0L4.34 251.47a12 12 0 0 0-1.6 16.9l25.5 31A12 12 0 0 0 45.15 301l235.22-193.74a12.19 12.19 0 0 1 15.3 0L530.9 301a12 12 0 0 0 16.9-1.6l25.5-31a12 12 0 0 0-1.7-16.93z" class=""></path></svg>`
  nav += `<a href="mailto:mail@ethanmerchant.com" target="blank">`
  nav += `<div style="margin-right: 1rem;">contact</div>`
  nav += `</a>`
  nav += `</div>`

  $('#nav').html(nav);
  $('#footer').html('<sub>&copy; 2021 ethan merchant</sub>');
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
