// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/musichub").build();

connection.start().then(function () {
  console.log("SignalR Connected");
}).catch(function (err) {
  return console.error(err.toString());
});

connection.on("ReceivePlaylistUpdate", function (userName, trackTitle) {
  showNotification(userName + " đã thêm bài hát '" + trackTitle + "' vào playlist công khai.");
});

function showNotification(message) {
  let notification = document.createElement('div');
  notification.className = 'alert alert-info alert-dismissible fade show';
  notification.role = 'alert';
  notification.innerHTML = `
    <strong>Cập nhật Playlist!</strong> ${message}
    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
      <span aria-hidden="true">&times;</span>
    </button>
  `;
  
  let container = document.querySelector('.container-fluid');
  container.insertBefore(notification, container.firstChild);
  
  setTimeout(function() {
    notification.remove();
  }, 5000);
}