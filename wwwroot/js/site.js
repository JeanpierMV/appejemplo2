// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const app = document.getElementById('typewriter');
const typewriter = new Typewriter(app,{
    loop:true, delay:75
});

typewriter
.typeString('La mejor comida')
.pauseFor(1000)
.start();