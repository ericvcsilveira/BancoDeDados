<template>
    <div class="container p-2">
        <h1 class="text-center mt-3">Olá {{this.aluno.nome}}</h1>

        <div class="container text-center mt-4 col-5">
            <div class="btn-group col-12">
                <button class="btn btn-danger col-6" @click="mostraCadastroTreino()">Cadastrar Treino</button>
                <button class="btn btn-primary col-6" @click="mostraTreino()">Meus Treinos</button>
            </div>

            <!--<div class="mt-2">
                <button class="btn btn-warning col-12" @click="mostraColetiva()">Coletivas</button>
            </div> -->

            <div class="mt-2">
                <button class="btn btn-success col-12" @click="mostraTreinoAtual()">Meu Treino Atual</button>
            </div>

        </div>
        <div v-show="cadastroTreino">
            <CadastraTreino :aluno="aluno" />
        </div>

        <div v-show="treino">
            <MostraTreino :mat="this.matricula"/>
        </div>

        <div v-show="treinoAtual">
            <TreinoAtual :mat="this.matricula"/>
        </div>

        
        
    </div>
</template>

<script>
import CadastraTreino from "@/components/CadastraTreino.vue";
import MostraTreino from "@/components/MostraTreino.vue";
import TreinoAtual from "@/components/TreinoAtual.vue";
import axios from "axios";
export default {
    name: 'TelaAluno',
    components: {
        CadastraTreino,
        MostraTreino,
        TreinoAtual,
    },
    props: {
        matricula: Number
    },
    data(){
        return{
            alunos: [],
            aluno: [],
            cadastroTreino: false,
            treino: false,
            treinoAtual: false
        }
    },
    methods: {
        refreshData() {
            axios.get("http://localhost:7632/api/Alunos").then((res) => {
                this.alunos = res.data;
                this.alunos.forEach(alu => {
                if (alu.matricula == this.matricula){
                    this.aluno = alu;
                }
              });
            });

        },

        mostraCadastroTreino(){
            this.cadastroTreino = !(this.cadastroTreino);
        },

        mostraTreino(){
            this.treino = !(this.treino);
        },

        mostraTreinoAtual(){
            this.treinoAtual = !(this.treinoAtual);
        }
    },

    mounted: function () {
        this.refreshData();
    },
}
</script>