function OnTabClick(e)
{
    var human_id = document.URL.slice(document.URL.indexOf("HumanID")).split("&")[0].split("=")[1];
    if (event?.currentTarget?.id != undefined && event?.currentTarget?.id != null) {
        if (event?.currentTarget?.id == "btnMedication") {
            $("#btnAllergies").removeClass("btncolorMyQ");
            $("#btnMedication").addClass("btncolorMyQ");
            $("#lblScreenDis")[0].innerText = "List of Duplicate Medications in Keep Account";
            $("#ifrmRcopiaDuplicateScreen")[0].src = "";
            $("#ifrmRcopiaDuplicateScreen")[0].src = "frmRCopiaDuplicateMediations.aspx?HumanID=" + human_id;
        }
        else if (event?.currentTarget?.id == "btnAllergies") {
            $("#btnMedication").removeClass("btncolorMyQ");
            $("#btnAllergies").addClass("btncolorMyQ");
            $("#lblScreenDis")[0].innerText = "List of Duplicate Allergies in Keep Account";
            $("#ifrmRcopiaDuplicateScreen")[0].src = ""
            $("#ifrmRcopiaDuplicateScreen")[0].src = "";
        }
    }
}
