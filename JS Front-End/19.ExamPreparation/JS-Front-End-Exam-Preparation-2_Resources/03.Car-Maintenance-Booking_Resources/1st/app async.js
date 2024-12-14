window.addEventListener("load", () => {
  const apiUrl = 'http://localhost:3030/jsonstore/appointments';

  const addAppointmentBtn = document.getElementById("add-appointment");
  const editAppointmentBtn = document.getElementById("edit-appointment");
  const loadAppointmentsBtn = document.getElementById("load-appointments");
  const appointmentsList = document.getElementById("appointments-list");

  const carModelInput = document.getElementById("car-model");
  const carServiceSelect = document.getElementById("car-service");
  const dateInput = document.getElementById("date");

  let currentEditId = null;

  // Helper function to clear inputs
  function clearInputs() {
    carModelInput.value = '';
    carServiceSelect.value = '';
    dateInput.value = '';
  }

  // Load appointments from the API
  async function loadAppointments() {
    appointmentsList.innerHTML = ''; // Clear the current list
    try {
      const response = await fetch(apiUrl);
      const data = await response.json();

      if (data) {
        Object.values(data).forEach((appointment) => {
          const li = document.createElement('li');
          li.classList.add('appointment');
          li.innerHTML = `
            <h2>${appointment.model}</h2>
            <h3>${appointment.date}</h3>
            <h3>${appointment.service}</h3>
            <div class="buttons-appointment">
              <button class="change-btn" data-id="${appointment._id}">Change</button>
              <button class="delete-btn" data-id="${appointment._id}">Delete</button>
            </div>
          `;
          appointmentsList.appendChild(li);

          // Add event listeners for each button
          li.querySelector('.change-btn').addEventListener('click', () => editAppointment(appointment._id));
          li.querySelector('.delete-btn').addEventListener('click', () => deleteAppointment(appointment._id));
        });
      }
    } catch (error) {
      console.error('Error loading appointments:', error);
    }
  }

  // Add new appointment to the API
  async function addAppointment() {
    const model = carModelInput.value;
    const service = carServiceSelect.value;
    const date = dateInput.value;

    if (!model || !service || !date) {
      alert("Please fill in all fields.");
      return;
    }

    const appointment = {
      model,
      service,
      date,
    };

    try {
      const response = await fetch(apiUrl, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(appointment),
      });

      if (response.ok) {
        clearInputs();
        await loadAppointments(); // Make sure appointments are fully loaded before proceeding
      }
    } catch (error) {
      console.error('Error adding appointment:', error);
    }
  }

  // Edit an existing appointment
  async function editAppointment(id) {
    try {
      const response = await fetch(`${apiUrl}/${id}`);
      const appointment = await response.json();

      if (appointment) {
        carModelInput.value = appointment.model;
        carServiceSelect.value = appointment.service;
        dateInput.value = appointment.date;
        currentEditId = id;

        addAppointmentBtn.disabled = true;
        editAppointmentBtn.disabled = false;
      }
    } catch (error) {
      console.error('Error loading appointment to edit:', error);
    }
  }

  // Save edited appointment to the API
  async function saveEditedAppointment() {
    const model = carModelInput.value;
    const service = carServiceSelect.value;
    const date = dateInput.value;

    if (!model || !service || !date) {
      alert("Please fill in all fields.");
      return;
    }

    const updatedAppointment = {
      model,
      service,
      date,
    };

    try {
      const response = await fetch(`${apiUrl}/${currentEditId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedAppointment),
      });

      if (response.ok) {
        clearInputs();
        await loadAppointments(); // Make sure appointments are fully loaded before proceeding
        addAppointmentBtn.disabled = false;
        editAppointmentBtn.disabled = true;
      }
    } catch (error) {
      console.error('Error editing appointment:', error);
    }
  }

  // Delete an appointment
  async function deleteAppointment(id) {
    try {
      const response = await fetch(`${apiUrl}/${id}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        await loadAppointments(); // Ensure the list is reloaded after deletion
      }
    } catch (error) {
      console.error('Error deleting appointment:', error);
    }
  }

  // Event Listeners
  loadAppointmentsBtn.addEventListener('click', async () => {
    await loadAppointments(); // Ensure all data is loaded before continuing
  });
  addAppointmentBtn.addEventListener('click', async () => {
    await addAppointment(); // Ensure appointment is added before continuing
  });
  editAppointmentBtn.addEventListener('click', async () => {
    await saveEditedAppointment(); // Ensure editing is completed before continuing
  });

  // Initial load
  loadAppointments();
});