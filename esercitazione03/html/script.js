function mostraMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu

    if (menu.style.display == 'none') { // se il menu è nascosto
        menu.style.display = 'block'; // mostra il menu
    } else { // altrimenti
        menu.style.display = 'none'; // nasconde il menu
    }
}

function chiudiMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu
    menu.style.display = 'none'; // nasconde il menu
}