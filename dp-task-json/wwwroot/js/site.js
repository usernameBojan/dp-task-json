const show = document.querySelector('.show');
const hide = document.querySelector('.hide');
const preview = document.querySelector('.preview');

show.addEventListener('click', () => preview.classList.remove('hidden'));
hide.addEventListener('click', () => preview.classList.add('hidden'));