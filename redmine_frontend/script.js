function populateProjectList(data) {
    const container = document.getElementById('ProjectList');

    container.innerHTML = '';

    console.log(data)

    data.forEach(item => {
        createProjectContainer(item,container);
    });
}

function createProjectContainer(projectRecord,location)
{
    let projectContainer = document.createElement('div');
    projectContainer.classList.add('projectContainer');

    let projectTitlebar = document.createElement('div');
    projectTitlebar.classList.add('projectTitlebar');
    projectTitlebar.textContent = projectRecord["name"];

    let projectContentArea = document.createElement('div');
    projectContentArea.classList.add('projectContentArea');
    projectContentArea.textContent = projectRecord["description"];

    let projectfooter = document.createElement('div');
    projectfooter.classList.add('projectfooter');
    projectfooter.textContent = "Feladat hozzáadása"

    projectContainer.appendChild(projectTitlebar);
    projectContainer.appendChild(projectContentArea);
    projectContainer.appendChild(projectfooter);
    
    location.appendChild(projectContainer);
}

function createTaskAddLayout(appendTo)
{
    console.log("lefut")
    let mainContainer = document.createElement('div');
    mainContainer.classList.add('taskAddContainer')

    let title = document.createElement('h1');
    title.textContent = "Feladat létrehozása";

    let name = document.createElement('div');
    name.textContent ="Név";
    let nameInput = document.createElement('input');

    let description = document.createElement('div');
    description.textContent = "Leírás"
    let descriptionInput = document.createElement('input');

    let developer = document.createElement('div');
    developer.textContent = "Fejlesztő";

    let developerSelect = document.createElement('select');

    mainContainer.appendChild(title);
    mainContainer.appendChild(name);
    mainContainer.appendChild(nameInput);
    mainContainer.appendChild(description);
    mainContainer.appendChild(descriptionInput);
    mainContainer.appendChild(developer);
    mainContainer.appendChild(developerSelect);
    appendTo.appendChild(mainContainer)
}

function loadWithGet(address,helperFunction)
{
    fetch(address)
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        helperFunction(data);
    })
    .catch(error => {
        console.error('Error:', error);
    });
}

function startUp()
{
    loadWithGet('http://localhost:5136/RedMineDataList/loadinitial', populateProjectList)
}

startUp();


// function filterByType(type, checkbox) {
//     if (checkbox.checked) {
//         // Filters by type
//     } else {
//         // Removes filter by type
//     }
// }

// function toggleDropdown() {

//     const dropdown = document.getElementById("filter-dropdown");

//     if (dropdown.style.visibility === "hidden") {
//         dropdown.style.visibility = "visible"
//     } else {
//         dropdown.style.visibility = "hidden"
//     }

// }