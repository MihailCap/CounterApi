<script setup lang="ts">
    import axios from 'axios';
    import { ref } from 'vue';
    let name = ref<string|null>(null);
    
    

  const creaCounters = () => {
    axios.post('http://localhost:5053/', { input: name })
      .then(response => {
        
      })
      .catch(error => {
        console.error(error);
      });
  }


</script>

<template>
    <label for="name">nome</label>
    <input type="text" v-model="name" />
    <button @click="creaCounters()">crea </button>

</template>

<style>
</style>