
function initializeTabEvent() {

    $("ul.tabs li").click(function () {
        $(".tab_content").hide();
        var activeTab = $(this).attr("rel");

        $("#" + activeTab).show();

        $("ul.tabs li").removeClass("active");
        $(this).addClass("active");

        $(".tab_drawer_heading").removeClass("d_active");
        $(".tab_drawer_heading[rel^='" + activeTab + "']").addClass("d_active");
    });
}

function activeTabInMobileVersion(ele) {
    $(".tab_content").hide();
    var activeTab = $(ele).attr("rel");
    $("#" + activeTab).show();

    $(".tab_container .d_active").removeClass("d_active");

    $(ele).addClass("d_active");
}