import {
  addTaskCallback,
  deleteTaskCallback,
  listTasksCallback,
  addTaskPromise,
  deleteTaskPromise,
  listTasksPromise,
  addTaskAsync,
  deleteTaskAsync,
  listTasksAsync
} from "./task.js";

//callback demo
addTaskCallback("Learn JS", (msg) => {
  console.log(msg);

  addTaskCallback("Practice Async", (msg) => {
    console.log(msg);

    listTasksCallback((list) => {
      console.log(list);
    });
  });
});

//promise demo
addTaskPromise("Read Book")
  .then(console.log)
  .then(() => listTasksPromise())
  .then(console.log);


// async/await demo
const runAsyncVersion = async () => {
  console.log(await addTaskAsync("Build Project"));
  console.log(await deleteTaskAsync("Learn JS"));
  console.log(await listTasksAsync());
};

runAsyncVersion();