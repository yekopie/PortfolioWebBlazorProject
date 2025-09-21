/**
* Template Name: Kelly
* Template URL: https://bootstrapmade.com/kelly-free-bootstrap-cv-resume-html-template/
* Updated: Aug 07 2024 with Bootstrap v5.3.3
* Author: BootstrapMade.com
* License: https://bootstrapmade.com/license/
*/

(function () {
    "use strict";
    /**
     * Apply .scrolled class to the body as the page is scrolled down
     */
    function toggleScrolled() {
        const selectBody = document.querySelector('body');
        const selectHeader = document.querySelector('#header');
        if (!selectHeader ||
            (!selectHeader.classList.contains('scroll-up-sticky') &&
                !selectHeader.classList.contains('sticky-top') &&
                !selectHeader.classList.contains('fixed-top'))) return;

        window.scrollY > 100 ? selectBody.classList.add('scrolled') : selectBody.classList.remove('scrolled');
    }
    document.addEventListener('scroll', toggleScrolled);
    window.addEventListener('load', toggleScrolled);

    const mobileNavToggleBtn = document.querySelector('.mobile-nav-toggle');

    function mobileNavToogle() {
        document.querySelector('body').classList.toggle('mobile-nav-active');
        mobileNavToggleBtn.classList.toggle('bi-list');
        mobileNavToggleBtn.classList.toggle('bi-x');
    }
    mobileNavToggleBtn.addEventListener('click', mobileNavToogle);

    /**
     * Hide mobile nav on same-page/hash links
     */
    document.querySelectorAll('#navmenu a').forEach(navmenu => {
        navmenu.addEventListener('click', () => {
            if (document.querySelector('.mobile-nav-active')) {
                mobileNavToogle();
            }
        });

    });

    /**
     * Toggle mobile nav dropdowns
     */
    document.querySelectorAll('.navmenu .toggle-dropdown').forEach(navmenu => {
        navmenu.addEventListener('click', function (e) {
            e.preventDefault();
            this.parentNode.classList.toggle('active');
            this.parentNode.nextElementSibling.classList.toggle('dropdown-active');
            e.stopImmediatePropagation();
        });
    });

    /**
     * Preloader
     */
    function removePreloader() {
        const preloader = document.querySelector('#preloader');
        if (preloader) {
            preloader.remove();
        }
    }

    /**
      * Scroll top button
      */
    const scrollTop = document.querySelector('.scroll-top');

    function toggleScrollTop() {
        if (scrollTop) {
            window.scrollY > 100 ? scrollTop.classList.add('active') : scrollTop.classList.remove('active');
        }
    }

    if (scrollTop) {
        scrollTop.addEventListener('click', (e) => {
            e.preventDefault();
            window.scrollTo({ top: 0, behavior: 'smooth' });
        });
    }

    document.addEventListener('scroll', toggleScrollTop);

    /**
     * Animation on scroll init (AOS)
     */
    function initAOS() {
        if (typeof AOS !== "undefined") {
            AOS.init({ duration: 600, easing: 'ease-in-out', once: true, mirror: false });
        }
    }

    /**
     * Animate the skills items on reveal (Waypoints)
     */
    function initSkillAnimations() {
        const skillsAnimation = document.querySelectorAll('.skills-animation');
        skillsAnimation.forEach((item) => {
            if (typeof Waypoint !== 'undefined') {
                new Waypoint({
                    element: item,
                    offset: '80%',
                    handler: function (direction) {
                        const progress = item.querySelectorAll('.progress .progress-bar');
                        progress.forEach(el => {
                            el.style.width = el.getAttribute('aria-valuenow') + '%';
                        });
                    }
                });
            }
        });
    }

    function initPureCounter() {
        if (typeof PureCounter !== "undefined") {
            new PureCounter();
        }
    }

    /**
  * Init swiper sliders
  */
    function initSwiper() {
        document.querySelectorAll(".init-swiper").forEach(function (swiperElement) {

            if (swiperElement.classList.contains("swiper-tab") && typeof initSwiperWithCustomPagination === "function") {
                initSwiperWithCustomPagination(swiperElement, config);
            } else {
                new Swiper(swiperElement, {
                    loop: true,
                    speed: 600,
                    slidesPerView: "auto",
                    autoplay: { delay: 5000 },
                    pagination: {
                        el: swiperElement.querySelector(".swiper-pagination"),
                        clickable: true
                    }
                });
            }
        });
    }

    /**
     * Initiate glightbox
     */
    function initGlightbox() {
        if (typeof GLightbox !== "undefined") {
            GLightbox({ selector: '.glightbox' });
        }
    }

    /**
     * Init isotope layout and filters
     */
    function initIsotope() {
        if (typeof imagesLoaded === "undefined" || typeof Isotope === "undefined") return;
        document.querySelectorAll('.isotope-layout').forEach(function (isotopeItem) {
            let layout = isotopeItem.getAttribute('data-layout') ?? 'masonry';
            let filter = isotopeItem.getAttribute('data-default-filter') ?? '*';
            let sort = isotopeItem.getAttribute('data-sort') ?? 'original-order';

            let initIsotope;
            imagesLoaded(isotopeItem.querySelector('.isotope-container'), function () {
                initIsotope = new Isotope(isotopeItem.querySelector('.isotope-container'), {
                    itemSelector: '.isotope-item',
                    layoutMode: layout,
                    filter: filter,
                    sortBy: sort
                });
            });

            isotopeItem.querySelectorAll('.isotope-filters li').forEach(function (filters) {
                filters.addEventListener('click', function () {
                    const activeFilter = isotopeItem.querySelector('.isotope-filters .filter-active');
                    if (activeFilter) activeFilter.classList.remove('filter-active');
                    this.classList.add('filter-active');
                    if (initIsotope) {
                        initIsotope.arrange({ filter: this.getAttribute('data-filter') });
                    }
                    initAOS();
                });
            });
        });
    }

    // Fonksiyonlarý Blazor tarafýnda OnAfterRenderAsync çaðýrabiliriz
    window.initGlobalScripts = function () {
        initAOS();
        initPureCounter();
        initSwiper();
        initGlightbox();
        initIsotope();
        initSkillAnimations();
        removePreloader();
    };

    // Ýlk sayfa yüklenince otomatik çalýþsýn
    window.addEventListener("load", () => {
        window.initGlobalScripts();
    });

})();