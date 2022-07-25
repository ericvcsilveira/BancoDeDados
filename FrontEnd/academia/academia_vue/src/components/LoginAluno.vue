<template>
    <div class="container-fluid text-center">
            <h1 class="titulo">Aluno</h1>
            <div class="row g-3">
                <div class="col-md-6 offset-md-2">
                    <input type="number" class="form-control" v-model="matricula" placeholder="Matrícula">
                </div>
                <div class="col-auto">
                    <button class="btn btn-success btn" @click="efetuaLogin()">Entrar</button>
                </div>
                
            </div>
            
            <button class="btn btn-warning col-8 mt-2 btn-lg" @click="cadastraAluno()">Cadastrar</button>
            <button class="btn btn-primary col-8 mt-2 btn-lg" @click="mostrarAlunos()">Ver Alunos Cadastrados</button>

            <div v-show="mostraAluno">
                <MostraAlunos/>
            </div>

            <hr class="m-4">

            <h1 class="titulo">Treinos</h1>
            <button class="btn btn-primary col-8 mt-2 btn-lg" @click="mostrarTreinos()">Ver todos os treinos</button>

            <div v-show="mostraTreino">
                <MostraTreinos/>
            </div>

        </div>
</template>

<script>
import MostraAlunos from "@/components/MostraAlunos.vue";
import MostraTreinos from "@/components/MostraTreinos.vue";
import axios from "axios";
export default {
    name: 'LoginAluno',
    components: {
        MostraAlunos,
        MostraTreinos,
    },
    data() {
        return{
            matricula: null,
            alunos: [],
            mostraAluno: false,
            verifica: 0,
            mostraTreino: false,
        }
    },
    methods: {
        refreshData() {
            axios.get("http://localhost:7632/api/Alunos").then((res) => {
                this.alunos = res.data;
            });
        },

        efetuaLogin(){
            this.alunos.forEach(aluno => {
                if (aluno.matricula == this.matricula){
                    this.verifica = 1
                    this.$router.push({path: '/aluno/'+this.matricula,  props: this.matricula})
                }
            });

            if (!this.verifica){
                alert("Usuário não cadastrado!")
            }

            
        },

        cadastraAluno(){
            this.$router.push({path: '/cadastro'})
        },

        mostrarAlunos(){
            this.mostraAluno = !(this.mostraAluno);
        },

        mostrarTreinos(){
            this.mostraTreino = !(this.mostraTreino);
        }
    },

    mounted: function () {
        this.refreshData();
    },
}
</script>