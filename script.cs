
/* ========================================
   1. AUTOMATIC FOOTER YEAR
======================================== */

const yearElement = document.getElementById("year");

if (yearElement) {
    yearElement.textContent = new Date().getFullYear();
}


/* ========================================
   2. MOBILE NAVIGATION
======================================== */

const menuToggle = document.getElementById("menuToggle");
const navLinks = document.getElementById("navLinks");

if (menuToggle && navLinks) {
    menuToggle.addEventListener("click", function () {
        const isOpen = navLinks.classList.toggle("active");

        menuToggle.setAttribute("aria-expanded", String(isOpen));

        menuToggle.innerHTML = isOpen
            ? '<i class="fa-solid fa-xmark"></i>'
            : '<i class="fa-solid fa-bars"></i>';
    });

    // Close menu when a navigation link is clicked
    navLinks.querySelectorAll("a").forEach(function (link) {
        link.addEventListener("click", function () {
            navLinks.classList.remove("active");

            menuToggle.setAttribute("aria-expanded", "false");

            menuToggle.innerHTML =
                '<i class="fa-solid fa-bars"></i>';
        });
    });

    // Close menu when clicking outside the navigation
    document.addEventListener("click", function (event) {
        const clickedInsideMenu = navLinks.contains(event.target);
        const clickedToggle = menuToggle.contains(event.target);

        if (!clickedInsideMenu && !clickedToggle) {
            navLinks.classList.remove("active");

            menuToggle.setAttribute("aria-expanded", "false");

            menuToggle.innerHTML =
                '<i class="fa-solid fa-bars"></i>';
        }
    });
}


/* ========================================
   3. PROFILE IMAGE FALLBACK
======================================== */

const profileImage = document.getElementById("profileImage");
const photoPlaceholder = document.getElementById("photoPlaceholder");

function showPhotoPlaceholder() {
    if (profileImage) {
        profileImage.style.display = "none";
    }

    if (photoPlaceholder) {
        photoPlaceholder.style.display = "flex";
    }
}

function showProfileImage() {
    if (profileImage) {
        profileImage.style.display = "block";
    }

    if (photoPlaceholder) {
        photoPlaceholder.style.display = "none";
    }
}

if (profileImage && photoPlaceholder) {
    profileImage.addEventListener("load", showProfileImage);
    profileImage.addEventListener("error", showPhotoPlaceholder);

    // Handle images that have already loaded or failed
    if (profileImage.complete) {
        if (
            profileImage.naturalWidth > 0 &&
            profileImage.naturalHeight > 0
        ) {
            showProfileImage();
        } else {
            showPhotoPlaceholder();
        }
    }
}
