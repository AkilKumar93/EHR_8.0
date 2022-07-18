$(document).ready(function () {
    
    $("#MeasureHeadings > fieldset > div > div").css("display", "none");
    var Source = window.location.search.split('?')[1].split('&')[0].replace("Source=", "");
    $("#MeasureHeadings ." + Source).css("display", "block");
    $("#MeasureDetails > fieldset > div > div > div").css("display", "none");
    $("#MeasureDetails > fieldset > div > div").css("display", "block");
    $("#MeasureDetails ." + Source).find("div:first").css("display", "block");
    $("#MeasureHeadings ." + Source).find("span").css({ "background-color": "white", "color": "black", "font-weight": "normal" });
    $("#MeasureHeadings ." + Source).find("span:first").css({ "background-color": "antiquewhite", "color": "brown", "font-weight": "bold" });
    $("#MeasureHeadings span").click(function (e) {
        $("span.MacraMeasure").css({ "background-color": "white", "color": "black", "font-weight": "normal" });
        $(e.currentTarget).css({ "background-color": "antiquewhite", "color": "brown", "font-weight": "bold" });
        $("#MeasureDetails > fieldset > div > div > div").css("display", "none");
        var Measure_heading = e.currentTarget.attributes.getNamedItem("name").value;
        var Measure_div = $("." + Measure_heading);
        $(Measure_div).css("display", "block");
    });
});
