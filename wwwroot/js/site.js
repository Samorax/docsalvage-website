// Hover styling (ports the DC `style-hover` attribute to plain DOM events).
document.querySelectorAll("[data-hover]").forEach(function (el) {
  var hov = el.getAttribute("data-hover");
  var base = el.getAttribute("style") || "";
  el.addEventListener("mouseenter", function () { el.setAttribute("style", base + ";" + hov); });
  el.addEventListener("mouseleave", function () { el.setAttribute("style", base); });
});

// Pricing calculator (only present on /pricing).
function recalc() {
  var tbEl = document.getElementById("tbRange");
  var invEl = document.getElementById("invRange");
  if (!tbEl || !invEl) return;
  var tb = Number(tbEl.value);
  var inv = Number(invEl.value);
  var fmt = function (n) { return "$" + Number(n).toLocaleString("en-US"); };
  document.getElementById("tbVal").textContent = tb;
  document.getElementById("invVal").textContent = inv;
  document.getElementById("storageCost").textContent = fmt(tb * 22);
  document.getElementById("processCost").textContent = fmt(inv * 1);
  document.getElementById("totalCost").textContent = fmt(tb * 22 + inv * 1);
}
document.addEventListener("DOMContentLoaded", recalc);
