// taskManager.js

// Simulated database
let tasks = [];

// Callback Version

// Add Task (Callback)
export const addTaskCallback = (task, callback) => {
  setTimeout(() => {
    tasks.push(task);
    callback(`Task "${task}" added successfully.`);
  }, 1000);
};

// Delete Task (Callback)
export const deleteTaskCallback = (task, callback) => {
  setTimeout(() => {
    tasks = tasks.filter(t => t !== task);
    callback(`Task "${task}" deleted successfully.`);
  }, 1000);
};

// List Tasks (Callback)
export const listTasksCallback = (callback) => {
  setTimeout(() => {
    callback(`
------ TASK LIST ------
${tasks.map((t, i) => `${i + 1}. ${t}`).join("\n")}
-----------------------
`);
  }, 1000);
};


// Promise Version

export const addTaskPromise = (task) => {
  return new Promise((resolve) => {
    setTimeout(() => {
      tasks.push(task);
      resolve(`Task "${task}" added successfully.`);
    }, 1000);
  });
};

export const deleteTaskPromise = (task) => {
  return new Promise((resolve) => {
    setTimeout(() => {
      tasks = tasks.filter(t => t !== task);
      resolve(`Task "${task}" deleted successfully.`);
    }, 1000);
  });
};

export const listTasksPromise = () => {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve(`
------ TASK LIST ------
${tasks.map((t, i) => `${i + 1}. ${t}`).join("\n")}
-----------------------
`);
    }, 1000);
  });
};


// Async Await Version

export const addTaskAsync = async (task) => {
  const message = await addTaskPromise(task);
  return message;
};

export const deleteTaskAsync = async (task) => {
  const message = await deleteTaskPromise(task);
  return message;
};

export const listTasksAsync = async () => {
  const list = await listTasksPromise();
  return list;
};