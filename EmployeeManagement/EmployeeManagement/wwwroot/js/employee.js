const apiUrl = "https://localhost:7065/api/employee";

/* ===============================
   LOAD EMPLOYEES
================================ */

function loadEmployees() {
    fetch(apiUrl)
        .then(res => res.json())
        .then(data => {
            let rows = "";
            data.forEach(emp => {
                rows += `
                <tr>
                    <td>${emp.eName}</td>
                    <td>${emp.age}</td>
                    <td>${emp.salary}</td>
                    <td class="action-btns">
                        <button onclick="editEmployee(${emp.employeeId})">Edit</button>
                        <button onclick="deleteEmployee(${emp.employeeId})">Delete</button>
                    </td>
                </tr>`;
            });
            document.getElementById("employeeTable").innerHTML = rows;
        });
}

/* ===============================
   MODAL CONTROLS
================================ */

function showForm() {
    document.getElementById("modalOverlay").style.display = "block";
    document.getElementById("employeeForm").style.display = "block";
    document.getElementById("formTitle").innerText = "Add Employee";

    employeeId.value = "";
    ename.value = "";
    age.value = "";
    salary.value = "";
}

function hideForm() {
    document.getElementById("modalOverlay").style.display = "none";
    document.getElementById("employeeForm").style.display = "none";
    employeeId.value = "";
}

/* ===============================
   EDIT
================================ */

function editEmployee(id) {
    fetch(`${apiUrl}/${id}`)
        .then(res => res.json())
        .then(emp => {
            document.getElementById("modalOverlay").style.display = "block";
            document.getElementById("employeeForm").style.display = "block";
            document.getElementById("formTitle").innerText = "Edit Employee";

            employeeId.value = emp.employeeId;
            ename.value = emp.eName;
            age.value = emp.age;
            salary.value = emp.salary;
        });
}

/* ===============================
   ADD / UPDATE
================================ */

function submitEmployee() {
    const id = parseInt(employeeId.value);

    const emp = {
        eName: ename.value,
        age: parseInt(age.value),
        salary: parseFloat(salary.value)
    };

    if (!id) {
        fetch(apiUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(emp)
        }).then(() => {
            hideForm();
            loadEmployees();
        });
    } else {
        fetch(`${apiUrl}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(emp)
        }).then(() => {
            hideForm();
            loadEmployees();
        });
    }
}

/* ===============================
   DELETE
================================ */

function deleteEmployee(id) {
    if (confirm("Are you sure you want to delete this employee?")) {
        fetch(`${apiUrl}/${id}`, { method: "DELETE" })
            .then(() => loadEmployees());
    }
}

/* ===============================
   INITIAL LOAD
================================ */

loadEmployees();
