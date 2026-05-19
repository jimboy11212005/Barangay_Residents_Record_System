const API_URL = "https://localhost:7283/api/residents";

const token =
    localStorage.getItem("token");

if(!token){

    window.location =
        "login.html";
}

let residentsData = [];

async function loadResidents() {
    try {
        const response = await axios.get(API_URL);

        residentsData = response.data;

        renderResidents(residentsData);

        loadStats(residentsData);
    }
    catch (error) {
        console.log(error);
    }
}

function renderResidents(data) {

    const table =
        document.getElementById("residentTable");

    table.innerHTML = "";

    data.forEach(resident => {

        table.innerHTML += `

            <tr>
                <td>${resident.residentId}</td>
                <td>${resident.firstName}</td>
                <td>${resident.lastName}</td>
                <td>${resident.gender}</td>
                <td>${resident.age}</td>
                <td>${resident.purok}</td>
                <td>${resident.pwdStatus}</td>
            </tr>
        `;
    });
}

function loadStats(data) {

    document.getElementById("totalResidents")
        .innerText = data.length;

    document.getElementById("childrenCount")
        .innerText = data.filter(x => x.age <= 12).length;

    document.getElementById("adultsCount")
        .innerText = data.filter(x => x.age >= 18).length;

    document.getElementById("pwdCount")
        .innerText = data.filter(x => x.pwdStatus === "Yes").length;
}

async function addResident() {

    const resident = {

        firstName:
            document.getElementById("firstName").value,

        lastName:
            document.getElementById("lastName").value,

        age:
            parseInt(
                document.getElementById("age").value
            ),

        gender:
            document.getElementById("gender").value,

        purok:
            document.getElementById("purok").value,

        address:
            document.getElementById("address").value,

        pwdStatus:
            document.getElementById("pwdStatus").value
    };

     try {

        await axios.post(API_URL, resident);

        alert("Resident Registered Successfully");

        loadResidents();
    }
    catch (error) {
        console.log(error);

        alert("Failed to Register Resident");
    }
}

function logout(){

    localStorage.removeItem("token");

    window.location =
        "login.html";
}

// SEARCH

document
.getElementById("searchBox")
.addEventListener("keyup", function () {

    const keyword =
        this.value.toLowerCase();

    const filtered =
        residentsData.filter(r =>

            r.firstName.toLowerCase().includes(keyword)
            ||
            r.lastName.toLowerCase().includes(keyword)
        );

    renderResidents(filtered);
});



loadResidents();