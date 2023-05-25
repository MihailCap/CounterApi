<script lang="ts" setup>
import { ref, watch } from 'vue';
import CounterButton from './CounterButton.vue';



const valore = ref(0);
let min = ref<number|null>(null);
let max = ref<number|null>(null);
let num = ref<number|null>(null);
watch(max, (maxV )=>{
    if(maxV != null && maxV < valore.value){
        if(min.value != null) {
            if(max.value != null && max.value > min.value){
                valore.value = maxV;
            }
        }else{
            valore.value = maxV;
        }
    }
})

watch(min, (minV )=>{
    if(minV != null && minV > valore.value){
        valore.value = minV;
    }
})

const incrementa = () => {
    if(valore.value < (max.value ?? Number.MAX_SAFE_INTEGER)){
        num.value!=null && num.value != 0 ? valore.value += num.value : valore.value++;
    }
}

const decrementa = () => {
    if(valore.value > (min.value ?? Number.MIN_SAFE_INTEGER)){
        num.value != null && num.value != 0? valore.value -= num.value : valore.value--;
    }
}

const reset = () => {
    valore.value=0;
    min.value = null;
    max.value = null;
}
</script>

<template>
    <span>Contatore</span>
    <br>
    <br>
    <br>
    <br>
    <div id="Cont">
        <label for="num">inserire di quanti numeri incrementare il contatore</label>
        <br>
        <input type="number" v-model="num">
        <br>
        <br>
        {{ valore }}
        <br>
        <label for="min">min </label>
        <input type="number" v-model="min">
        &nbsp;
        <input type="number" v-model="max">
        <label for="max"> max</label>
        <br>
        <br>
        <CounterButton @click="decrementa" id="btnMeno" class="bottone"  :disabled="!(min == null) && valore <= min">-</CounterButton>
        &nbsp;
        <CounterButton @click="reset" id="btnReset" class="bottone" >reset</CounterButton>
        &nbsp;
        <CounterButton @click="incrementa" id="btnPiù" class="bottone"  :disabled="!(max == null) && valore >= max">+</CounterButton>
       
        
    </div>
</template>

<style scoped>
    input{
        text-align: center;
    }
    div{
        align-items: center;
        text-align: center;
        color: cadetblue;
        font-size: 25px;
        margin:auto;
        width:200%;
        border: 3px solid white;
        padding:10%;
        margin-bottom: 70px;
        border-radius: 10px;
    }
    span{
        margin-left:90%;
        
        font-size: 30px;
    
    }
    #btnPiù{
        background-color: green;
    }

    #btnPiù:disabled, #btnMeno:disabled{
        background-color: grey;
    }

    #btnMeno{
        background-color: red;
        
    }
    #btnReset{
        background-color: ghostwhite;
        font-size: 30px;
    }

    label{
        color:darkcyan;
    }
    #Cont{
        background-color:rgb(59, 59, 59);
    }
    .bottone{
        border:none;
    }
</style>