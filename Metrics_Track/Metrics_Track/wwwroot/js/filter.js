function myFunction(ids) {
    var input, filter, ul, li, a, i;
    input = document.getElementById("inputName");
    filter = input.value.toUpperCase();
    ul = document.getElementById(ids);
    li = ul.getElementsByTagName("option");
    for (i = 0; i < li.length; i++) {
        if (li[i].innerHTML.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}