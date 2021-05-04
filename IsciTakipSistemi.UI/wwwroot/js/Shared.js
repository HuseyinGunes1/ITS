const showMenu = (toggleId, navbarId, bodyId) => {
    const toggle = document.getElementById(toggleId),
        navbar = document.getElementById(navbarId)
    bodypadding = document.getElementById(bodyId)

    if (toggle && navbar) {
        toggle.addEventListener('click', () => {
            navbar.classList.toggle('expander')
            bodypadding.classList.toggle('body-pd')
        })
    }
}
showMenu('nav-toggle', 'navbar', 'body-pd')

$("#selectAll").change(function () {
    $(".checkbox1").prop("checked", $(this).prop("checked"))
});
$(".checkbox1").change(function () {
    if ($(this).prop("checked") == false) {
        $("#selectAll").prop("checked", false)
    }
    if ($(".checkbox1:checked").length == $(".checkbox1").length) {
        $("#selectAll").prop("checked", true)
    }
});