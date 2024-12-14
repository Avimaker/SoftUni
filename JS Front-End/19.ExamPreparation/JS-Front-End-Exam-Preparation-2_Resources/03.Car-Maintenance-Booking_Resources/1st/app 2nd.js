function loadAppointments(baseUrl, onSuccess) {
    fetch(baseUrl)
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
}

function createAppointment(baseUrl, appointment, onSuccess) {
    fetch(baseUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(appointment)
    })
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
}

function updateAppointment(baseUrl, appointment, onSuccess) {
    fetch(baseUrl + appointment._id, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(appointment)
    })
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
}

function deleteAppointment(baseUrl, appointmentId, onSuccess) {
    fetch(baseUrl + appointmentId, {
        method: 'DELETE'
    })
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
}

function createElement(tag, properties, container) {
    const element = document.createElement(tag);

    Object.keys(properties).forEach(key => {
        if (typeof properties[key] === 'object') {
            element[key] ??= {};
            Object.assign(element[key], properties[key]);
        } else {
            element[key] = properties[key];
        }
    });

    if (container) container.append(element);

    return element;
}

function init() {
    const baseUrl = 'http://localhost:3030/jsonstore/appointments/';

    const fields = {
        model: document.querySelector('#car-model'),
        service: document.querySelector('#car-service'),
        date: document.querySelector('#date')
    };

    const btnAddAppointment = document.querySelector('#add-appointment');
    const btnEditAppointment = document.querySelector('#edit-appointment');
    const btnLoadAppointments = document.querySelector('#load-appointments');
    const appointmentsList = document.querySelector('#appointments-list');

    let activeAppointmentId = null;

    btnAddAppointment.addEventListener('click', addAppointmentHandler);
    btnEditAppointment.addEventListener('click', editAppointmentHandler);
    btnLoadAppointments.addEventListener('click', loadAppointmentsHandler);

    function loadAppointmentsHandler() {
        appointmentsList.innerHTML = '';
        loadAppointments(baseUrl, (appointments) => {
            Object.values(appointments).forEach(createAppointmentElement);
        });
    }

    function createAppointmentElement({ model, date, service, _id }) {
        const appointmentEl = createElement('li', { className: 'appointment' }, appointmentsList);

        createElement('h2', { textContent: model }, appointmentEl);
        createElement('h3', { textContent: date }, appointmentEl);
        createElement('h3', { textContent: service }, appointmentEl);

        const buttonsWrapper = createElement('div', { className: 'buttons-appointment' }, appointmentEl);

        createElement('button', {
            className: 'change-btn',
            textContent: 'Change',
            onclick: () => changeAppointmentHandler({ model, date, service, _id })
        }, buttonsWrapper);

        createElement('button', {
            className: 'delete-btn',
            textContent: 'Delete',
            onclick: () => deleteAppointmentHandler(_id)
        }, buttonsWrapper);
    }

    function addAppointmentHandler(e) {
        e.preventDefault();

        const model = fields.model.value;
        const service = fields.service.value;
        const date = fields.date.value;

        if (!model || !service || !date) return;

        const newAppointment = { model, service, date };

        createAppointment(baseUrl, newAppointment, () => {
            loadAppointmentsHandler();
            clearFields();
        });
    }

    function changeAppointmentHandler({ model, date, service, _id }) {
        activeAppointmentId = _id;
        fields.model.value = model;
        fields.service.value = service;
        fields.date.value = date;

        btnAddAppointment.disabled = true;
        btnEditAppointment.disabled = false;
    }

    function editAppointmentHandler(e) {
        e.preventDefault();

        const model = fields.model.value;
        const service = fields.service.value;
        const date = fields.date.value;

        if (!model || !service || !date) return;

        const updatedAppointment = { model, service, date, _id: activeAppointmentId };

        updateAppointment(baseUrl, updatedAppointment, () => {
            loadAppointmentsHandler();
            clearFields();
            btnAddAppointment.disabled = false;
            btnEditAppointment.disabled = true;
            activeAppointmentId = null;
        });
    }

    function deleteAppointmentHandler(appointmentId) {
        deleteAppointment(baseUrl, appointmentId, () => {
            loadAppointmentsHandler();
        });
    }

    function clearFields() {
        fields.model.value = '';
        fields.service.value = '';
        fields.date.value = '';
    }
}

document.addEventListener('DOMContentLoaded', init);