<template>
    <div class="container" id="todo">
  <header class="header">
    <h1>Todo App ({{ tasks.length }})</h1>    
  </header>
  <section class="panel">
    <input
        type="checkbox"
        @click="selectAll"
        :checked="areAllSelected">

    <input
        v-model="newTask"
        @keyup.enter="addTask"
        placeholder="What do you need to do?"
        class="text-input">

    <select v-model="selectedPriority" class="priority">
      <option v-for="prio in priorities" :value="prio">{{ prio.label }}</option>
    </select>
    
    <button @click="clearList">{{ areAnySelected ? 'Delete Selected' : 'Clear List'}}</button>
  </section>

  <section class="list">
    <ul v-if="tasks.length > 0">
      <li
          v-for="task in tasks"
          :class="{done: task.checked, low: task.priority.prio === 0}">
        <input
            type="checkbox"
            v-model="task.checked">
        <label for="checkbox">[{{ task.priority.label }}] {{ task.text }}</label>
        <button @click="removeTask(task)">X</button>
      </li>
    </ul>
export default class ToDoCard extends Vue {
new Vue({
  el: "#todo",

  // Initial app state.
  data() {
    return {
      newTask: "",
      tasks: [
        {
          text: "This is an example task. Delete or add your own",
          priority: {label: 'low', prio: 2},
          checked: false,
        },
      ],
      priorities: [{prio: 2, label: 'low'}, {prio: 1, label: 'medium'}, {prio: 0, label: 'high'}],
      selectedPriority: {prio: 2, label: 'low'},
    };
  },

  // Computed properties accessed via `this.name` (or {{ name }}
  // in the template).
  computed: {
    areAllSelected() {
      return (
        this.tasks.every((task) => {
          return task.checked;
        }) && this.tasks.length > 0
      );
    },
    areAnySelected() {
      return this.tasks.some(({ checked }) => checked)
    },
    taskClasses(task) {
      const classes = {
        done: task.checked,
        [task.priority.prio]: true,
      }
      console.log(classes)
      return classes;
    }
  },

  // Methods called via `this.name()` (or {{ name() }} in the template).
  methods: {
    addTask() {
      const task = this.newTask.trim();
      const priority = this.selectedPriority;
      
      if (task) {
        this.tasks.push({ text: task, checked: false, priority });
        this.tasks = this.tasks.sort((a,b) => a.priority.prio - b.priority.prio);
        console.log(this.tasks)
        this.newTask = "";
      }
    },

    removeTask(task) {
      const index = this.tasks.indexOf(task);
      this.tasks.splice(index, 1);
    },

    clearList() {
      console.log(this.tasks)
      if (this.areAnySelected) {
        this.tasks = this.tasks.filter(({checked}) => !checked)       
      } else {
          this.tasks = [];        
      }
    },

    selectAll(task) {
      const targetValue = !this.areAllSelected;

      this.tasks.forEach((task) => {
        task.checked = targetValue;
      });
    },
  },
});