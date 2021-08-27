var myCollapsible = document.getElementById("collapse-navbar");

myCollapsible.addEventListener("show.bs.collapse", function () {
  var banner = document.getElementById("topCasaFina-banner");
  banner.classList.remove("translate-middle");
  banner.style.transform = "translate(-50%,-10%)";
  banner.style.transition = ".3s";
});

myCollapsible.addEventListener("hide.bs.collapse", function () {
  var banner = document.getElementById("topCasaFina-banner");
  banner.style.transform = "none";
  banner.classList.add("translate-middle");
});
