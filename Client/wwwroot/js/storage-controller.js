window.addEventListener('beforeunload', e => {
    localStorage.removeItem('onDisplay');
});
