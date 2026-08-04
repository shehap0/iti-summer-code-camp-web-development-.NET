(() => {
    'use strict';

    /* Theme toggle */
    const root = document.documentElement;
    const toggle = document.getElementById('themeToggle');
    if (toggle) {
        toggle.addEventListener('click', () => {
            const next = root.getAttribute('data-theme') === 'dark' ? 'light' : 'dark';
            root.setAttribute('data-theme', next);
            localStorage.setItem('theme', next);
        });
    }

    /* Mobile portal sidebar */
    const menuBtn = document.getElementById('portalMenuBtn');
    const sidebar = document.getElementById('portalSidebar');
    if (menuBtn && sidebar) {
        menuBtn.addEventListener('click', () => sidebar.classList.toggle('open'));
        document.addEventListener('click', (e) => {
            if (sidebar.classList.contains('open') &&
                !sidebar.contains(e.target) &&
                !menuBtn.contains(e.target)) {
                sidebar.classList.remove('open');
            }
        });
    }

    /* Reveal on scroll */
    const reveals = document.querySelectorAll('.reveal');
    if (reveals.length && 'IntersectionObserver' in window) {
        const observer = new IntersectionObserver((entries) => {
            entries.forEach((entry) => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('visible');
                    observer.unobserve(entry.target);
                }
            });
        }, { threshold: 0.08, rootMargin: '0px 0px -30px 0px' });
        reveals.forEach((el, i) => {
            el.style.transitionDelay = `${Math.min((i % 6) * 60, 300)}ms`;
            observer.observe(el);
        });
    } else {
        reveals.forEach((el) => el.classList.add('visible'));
    }

    /* Flash messages */
    document.querySelectorAll('.flash').forEach((flash) => {
        setTimeout(() => dismiss(flash), 6000);
        const closeBtn = flash.querySelector('.flash-close');
        if (closeBtn) closeBtn.addEventListener('click', () => dismiss(flash));
    });
    function dismiss(el) {
        el.style.transition = 'opacity .4s, transform .4s';
        el.style.opacity = '0';
        el.style.transform = 'translateY(-10px)';
        setTimeout(() => el.remove(), 400);
    }

    /* File upload feedback */
    document.querySelectorAll('[data-file-upload] input[type="file"]').forEach((input) => {
        input.addEventListener('change', () => {
            const text = input.closest('[data-file-upload]').querySelector('.file-upload-text');
            if (input.files && input.files.length) {
                text.textContent = input.files[0].name;
                text.style.fontWeight = '700';
            }
        });
    });

    /* Toast */
    window.toast = (message) => {
        const toastEl = document.getElementById('toast') || createToast();
        toastEl.textContent = message;
        toastEl.classList.add('show');
        clearTimeout(window.__toastTimer);
        window.__toastTimer = setTimeout(() => toastEl.classList.remove('show'), 2600);
    };
    function createToast() {
        const el = document.createElement('div');
        el.className = 'toast';
        el.id = 'toast';
        el.setAttribute('role', 'status');
        document.body.appendChild(el);
        return el;
    }
})();
