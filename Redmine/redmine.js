// Felhasználói adatok beállítása
const userInfo = {
    name: "Ódor Patrik",
    id: "L61KCM"
};
// Felhasználói adatok megjelenítése
function showUserInfo() {
    document.getElementById('name').textContent = userInfo.name;
    document.getElementById('id').textContent = "ID: " + userInfo.id;
}

// Oldal betöltésekor futtatjuk a funkciókat
window.onload = function() {
    showUserInfo();
};



