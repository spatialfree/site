$(document).ready(function () {
  var nav = `<div style="display: flex; justify-content: space-between; align-items: center; border-bottom: 2px solid #666; background: gray;">`
  nav += `<a href="/">` // javascript:javascript:history.go(-1)
  nav += `<img src="/res/icons/home-icon.svg" style="margin: 1rem; width: 32px; height: 32px;" />`
  nav += `</a>`
  nav += `</div>`

  $('#nav').html(nav);
  $('#footer').html('&copy; 2022 Ethan Merchant');
})
