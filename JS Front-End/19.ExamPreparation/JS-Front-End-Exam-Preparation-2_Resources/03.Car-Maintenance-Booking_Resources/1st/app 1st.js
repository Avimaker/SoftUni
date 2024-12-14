window.addEventListener("load", function () {
  const baseUrl = 'http://localhost:3030/jsonstore/appointments';

  const addAppointmentBtn = document.getElementById("add-appointment");
  const editAppointmentBtn = document.getElementById("edit-appointment");
  const loadAppointmentsBtn = document.getElementById("load-appointments");
  const appointmentsList = document.getElementById("appointments-list");

  const carModelInput = document.getElementById("car-model");
  const carServiceSelect = document.getElementById("car-service");
  const dateInput = document.getElementById("date");

  let currentEditId = '';

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
        const response = await fetch(baseUrl);
        const data = await response.json();

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

            // Attach event listeners for buttons
            li.querySelector('.change-btn').addEventListener('click', () => editAppointment(appointment._id));
            li.querySelector('.delete-btn').addEventListener('click', () => deleteAppointment(appointment._id));
        });
    } catch (error) {
        console.error('Error loading appointments:', error);
    }
}

  // Add a new appointment to the API
  async function addAppointment() {
      const model = carModelInput.value;
      const service = carServiceSelect.value;
      const date = dateInput.value;

      if (!model || !service || !date) {
          alert("Please fill in all fields.");
          return;
      }

      const appointment = { model, service, date };

      try {
          const response = await fetch(baseUrl, {
              method: 'POST',
              headers: { 'Content-Type': 'application/json' },
              body: JSON.stringify(appointment),
          });

          if (response.ok) {
              clearInputs();
              await loadAppointments(); // Reload appointments
          }
      } catch (error) {
          console.error('Error adding appointment:', error);
      }
  }

  // Edit an existing appointment
  async function editAppointment(id) {
      try {
          const response = await fetch(`${baseUrl}/${id}`);
          const appointment = await response.json();

          carModelInput.value = appointment.model;
          carServiceSelect.value = appointment.service;
          dateInput.value = appointment.date;
          currentEditId = id;

          // Adjust button states
          addAppointmentBtn.disabled = true;
          editAppointmentBtn.disabled = false;
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

      const updatedAppointment = { model, service, date };

      try {
          const response = await fetch(`${baseUrl}/${currentEditId}`, {
              method: 'PUT',
              headers: { 'Content-Type': 'application/json' },
              body: JSON.stringify(updatedAppointment),
          });

          if (response.ok) {
              clearInputs();
              currentEditId = null;
              await loadAppointments(); // Reload appointments

              // Reset button states
              addAppointmentBtn.disabled = false;
              editAppointmentBtn.disabled = true;
          }
      } catch (error) {
          console.error('Error saving edited appointment:', error);
      }
  }

  // Delete an appointment
  async function deleteAppointment(id) {
    if (!id) {
        console.error('Invalid appointment ID for deletion.');
        return;
    }

    try {
        const response = await fetch(`${baseUrl}/${id}`, { method: 'DELETE' });

        if (response.ok) {
            await loadAppointments(); // Reload appointments
        } else {
            console.error(`Failed to delete appointment with ID: ${id}`);
        }
    } catch (error) {
        console.error('Error deleting appointment:', error);
    }
}

  // Attach event listeners
  loadAppointmentsBtn.addEventListener('click', loadAppointments);
  addAppointmentBtn.addEventListener('click', addAppointment);
  editAppointmentBtn.addEventListener('click', saveEditedAppointment);

  // Initial load of appointments
  loadAppointments();
});