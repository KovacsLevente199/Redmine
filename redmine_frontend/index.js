function loginUser() {
    var uname = document.getElementById("exampleInputEmail1").value;
    var pw = document.getElementById("exampleInputPassword1").value;


    fetch('https://localhost:7295/RedMineDataList/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            Accept: 'application/json',
        },
        body: JSON.stringify({
            userName: uname,
            password: pw
        })
    })
    .then(response => {
        if (response.ok) {
            const authToken = response.headers.get('authorization')
            sessionStorage.clear();
            sessionStorage.setItem('token', authToken);
            window.location.href = "dashboard.html";
        }
        else{
            window.alert("Helytelen felhasználó név vagy jelszó!");
        }
        
    })
    .catch(error => {
        console.error('There has been a problem with your fetch operation:', error);
    });
}    