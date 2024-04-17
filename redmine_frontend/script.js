var GLOBALprojectsList = [0];

function populateProjectList(data) {
    const container = document.getElementById('ProjectList');
    container.innerHTML = '';
    data.forEach(item => {
        createProjectContainer(item,container);
    });

    generateSoonestTask();
}

function createProjectContainer(projectRecord,location)
{
    GLOBALprojectsList.push(projectRecord["name"])
    
    let projectContainer = document.createElement('div');
    projectContainer.classList.add('project-container');
    projectContainer.setAttribute('data-project-type', projectRecord["typeID"]);
    projectContainer.setAttribute('data-project-id', projectRecord["id"]);

    let projectDetails = document.createElement('div');
    projectDetails.classList.add('project-details');

    let projectTitlebar = document.createElement('div');
    projectTitlebar.classList.add('project-title');
    projectTitlebar.textContent = projectRecord["name"];

    let projectContentArea = document.createElement('div');
    projectContentArea.classList.add('project-content-area');
    projectContentArea.textContent = projectRecord["description"];
    

    let projectfooter = document.createElement('div');
    projectfooter.classList.add('project-footer');

    let addTaskBtn = document.createElement('button');
    addTaskBtn.classList.add('add-task-btn');
    addTaskBtn.textContent = "Feladat hozzáadása"
    addTaskBtn.addEventListener("click", (e) => {
        const parentWrapper = e.target.parentNode.parentNode.parentNode;
        const createTaskWrapper = parentWrapper.querySelector(".create-task-wrapper");
        if (createTaskWrapper.style.display === "none") {
            createTaskWrapper.style.display = "flex"
        } else {
             createTaskWrapper.style.display = "none"
        }
        

    })

    projectfooter.appendChild(addTaskBtn);
    
    

    let listProjectTasksBtn = document.createElement('button');
    listProjectTasksBtn.classList.add('list-task-btn');
    listProjectTasksBtn.textContent = 'Feladatok listázása';
    projectfooter.appendChild(listProjectTasksBtn);
    
    
    listProjectTasksBtn.addEventListener("click", (e) => {
        const parentWrapper = e.target.parentNode.parentNode.parentNode;
        
        const createTaskWrapper = parentWrapper.querySelector(".list-assigned-tasks-wrapper");
        
        if (createTaskWrapper.style.display === "none") {
            createTaskWrapper.style.display = "flex"
        } else {
             createTaskWrapper.style.display = "none"
        }  
    })
    
    
    
    projectDetails.appendChild(projectTitlebar);
    projectDetails.appendChild(projectContentArea);
    projectDetails.appendChild(projectfooter);
    projectContainer.appendChild(projectDetails);
    createTaskAddLayout(projectContainer)
    listAssignedTasks(projectContainer.getAttribute('data-project-id'),projectContainer)
    
    location.appendChild(projectContainer);
}

function createTaskAddLayout(appendTo)
{
    let mainContainer = document.createElement('div');
    mainContainer.classList.add('create-task-wrapper')
    mainContainer.style.display = "none"

    let name = document.createElement('div');
    name.textContent ="Név";
    let nameInput = document.createElement('input');
    nameInput.classList.add('name-input')

    let description = document.createElement('div');
    description.textContent = "Leírás"
    let descriptionInput = document.createElement('input');
    descriptionInput.classList.add('description-input')

    let time = document.createElement('div');
    time.textContent ="Határidő";
    let timeInput = document.createElement('input');
    timeInput.classList.add('time-input')
    timeInput.type = "date";

    let developer = document.createElement('div');
    developer.textContent = "Fejlesztő";
    let developerSelect = document.createElement('select');
    developerSelect.classList.add('developer-input')

    fetch("https://localhost:7295/RedMineDataList/listdevelopers", {
        method: "POST"
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        data.forEach(developer => {
            let option = document.createElement('option');
            option.value = developer.id; 
            option.textContent = developer.name;
            developerSelect.appendChild(option);
        });
    })
    .catch(error => {
        console.error('Error:', error);
    });




    let submitButton = document.createElement('button');
    submitButton.textContent = "Küldés"
    submitButton.classList.add("submit-btn");
    submitButton.addEventListener("click", (event) => {
        const taskWrapper = event.target.parentNode
        const data = {
            "name": taskWrapper.querySelector(".name-input").value.toString(),
            "deadline": new Date(taskWrapper.querySelector(".time-input").value).toISOString(),
            "projectID": taskWrapper.parentNode.getAttribute('data-project-id'),
            "description": taskWrapper.querySelector(".description-input").value.toString(),
            "developerID": taskWrapper.querySelector(".developer-input").value,
        }
        submitTask(data)
    })



    mainContainer.appendChild(name);
    mainContainer.appendChild(nameInput);
    mainContainer.appendChild(description);
    mainContainer.appendChild(descriptionInput);
    mainContainer.appendChild(time);
    mainContainer.appendChild(timeInput);
    mainContainer.appendChild(developer);
    mainContainer.appendChild(developerSelect);
    mainContainer.appendChild(submitButton);

    appendTo.appendChild(mainContainer)
}

function submitTask(data) {
    fetch("https://localhost:7295/RedMineDataList/addtask", {
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
        },
        method: "POST",
        body: JSON.stringify(data)
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            data.forEach(developer => {
                let option = document.createElement('option');
                option.value = developer.id; 
                option.textContent = developer.name;
                developerSelect.appendChild(option);
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });
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


function filterByType(type, checkbox) {
    if (checkbox.checked) {
        document.querySelectorAll(".project-container").forEach((element) => {
            if (element.getAttribute('data-project-type') !== type.toString()) {
                element.style.display = "none";
            }
        })
        console.log(type)
        
    } else {
        document.querySelectorAll(".project-container").forEach((element) => {
            if (element.getAttribute('data-project-type') !== type.toString()) {
                element.style.display = "flex";
            }
        })
    }
}

function toggleDropdown() {

    const dropdown = document.getElementById("filter-dropdown");

    if (dropdown.style.visibility === "hidden") {
        dropdown.style.visibility = "visible"
    } else {
        dropdown.style.visibility = "hidden"
    }

}

function generateSoonestTask(){
    const url = 'https://localhost:7295/RedMineDataList/taskdeadline';
const data = {
    userID:1
};

const options = {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
};

fetch(url, options)
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        generateTaskContainer(data);
    })
    .catch(error => {
        console.error('Error:', error);
    });

}

function generateTaskContainer(record)
{
    let displayNode = document.getElementById('expiring-container');

    let projectName = document.createElement('h3');
    projectName.textContent = GLOBALprojectsList[record['projectID']]
    let taskName = document.createElement('div');
    taskName.textContent = record['name']

    let taskDesc = document.createElement('div');
    taskDesc.textContent = record['description'];

    displayNode.appendChild(projectName);
    displayNode.appendChild(taskName);
    displayNode.appendChild(taskDesc);
}


function listAssignedTasks(param,parentnode)
{
    const url = 'https://localhost:7295/RedMineDataList/assignedtasks'; 


const data = {
    "projectID": param
};


const options = {
    method: 'POST', 
    headers: {
        'Content-Type': 'application/json' 
    },
    body: JSON.stringify(data) 
};

fetch(url, options)
    .then(response => {

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        return response.json();
    })
    .then(data => {
        generateTaskRecords(data,parentnode);
    })
    .catch(error => {

        console.error('Error:', error);
    });

}

function generateTaskRecords(data ,node)
{
    console.log(data[0]);
    let taskContrainer = document.createElement('div');
    taskContrainer.classList.add('list-assigned-tasks-wrapper');
    taskContrainer.style.display = "none"

    let taskName = document.createElement('div');
    taskName.textContent ="Név: " + data['name'];
    
    let taskDesc = document.createElement('div');
    taskDesc.textContent = "Leírás: "+ data['description'];  

    taskContrainer.appendChild(taskName);
    taskContrainer.appendChild(taskDesc)
    node.appendChild(taskContrainer);
}

startUp();