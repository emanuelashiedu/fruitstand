var sidebarMenu = {
    toggle: function () {


        //Get the screen sizes


        //Enable sidebar toggle
        //Enable sidebar push menu
        if ($(window).width() > (sidebarMenu.screenSizes.sm - 1)) {
            if ($("body").hasClass('sidebar-collapse')) {
                $("body").removeClass('sidebar-collapse').trigger('expanded.pushMenu');
            } else {
                $("body").addClass('sidebar-collapse').trigger('collapsed.pushMenu');
            }
        }
            //Handle sidebar push menu for small screens
        else {
            if ($("body").hasClass('sidebar-open')) {
                $("body").removeClass('sidebar-open').removeClass('sidebar-collapse').trigger('collapsed.pushMenu');
            } else {
                $("body").addClass('sidebar-open').trigger('expanded.pushMenu');
            }
        }
        $(".content-wrapper").click(function () {
            //Enable hide menu when clicking on the content-wrapper on small screens
            if ($(window).width() <= (sidebarMenu.screenSizes.sm - 1) && $("body").hasClass("sidebar-open")) {
                $("body").removeClass('sidebar-open');
            }
        });

        //Enable expand on hover for sidebar mini
        if (false || ($('body').hasClass('fixed') && $('body').hasClass('sidebar-mini'))) {
            this.expandOnHover();
        }
    },
    expandOnHover: function () {
        var _this = this;
        var screenWidth = this.screenSizes.sm - 1;
        //Expand sidebar on hover
        $('.main-sidebar').hover(function () {
            if ($('body').hasClass('sidebar-mini')
                    && $("body").hasClass('sidebar-collapse')
                    && $(window).width() > screenWidth) {
                _this.expand();
            }
        }, function () {
            if ($('body').hasClass('sidebar-mini')
                    && $('body').hasClass('sidebar-expanded-on-hover')
                    && $(window).width() > screenWidth) {
                _this.collapse();
            }
        });
    },
    expand: function () {
        $("body").removeClass('sidebar-collapse').addClass('sidebar-expanded-on-hover');
    },
    collapse: function () {
        if ($('body').hasClass('sidebar-expanded-on-hover')) {
            $('body').removeClass('sidebar-expanded-on-hover').addClass('sidebar-collapse');
        }
    },
    closeInMobileVersion: function () {

        if ($(window).width() < (this.screenSizes.sm - 1)) {
            if ($("body").hasClass('sidebar-open')) {
                $("body").removeClass('sidebar-open').removeClass('sidebar-collapse').trigger('collapsed.pushMenu');
            } else {
                $("body").addClass('sidebar-open').trigger('expanded.pushMenu');
            }
        }
    },
    screenSizes: {
        xs: 480,
        sm: 768,
        md: 992,
        lg: 1200
    }
};