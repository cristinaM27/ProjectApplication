
$('#linkClose').click(function () {
    $('#divError').hide('fade');
});
$('#btnLogin').click(function () {
    var user = { Username: $('#txtUsername').val(), Password: $('#txtPassword').val() };
        $.ajax({
            url: 'http://localhost:51060/api/Views/Login/SignIn',
            type: "POST",
            contentType: 'application/json',
            data:
            JSON.stringify(user),           
           success: function (response) {
                if (status == "success") 
                    sessionStorage.setItem('accesToken', response.access_token);
                    sessionStorage.setItem('userName', response.userName);
                    window.location.href = "Data.html";
            },
            error: function (error) {
                alert("Usename or password incorrect!");
            }
        });
    });