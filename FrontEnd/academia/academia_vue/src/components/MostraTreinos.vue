<template>
    <div class="container col-12 mb-3 mt-3 border border-primary rounded-3 p-4">
        <h3>Treinos</h3>

        <div v-for="treino in this.treinos" :key="treino.id">
            <hr>
            <h5 class="text-center mt-2 text-danger">Treino {{treino.id}}</h5>
            
            <fieldset disabled>

            <div class="input-group flex-nowrap mb-2">
                <span class="input-group-text text-primary">Aluno</span>
                <div v-for="aluno in this.alunos" :key="aluno.matricula">
                    <div v-if="aluno.matricula == treino.matricula">
                        <input type="text" class="form-control bg-white" v-model="aluno.nome" />
                    </div>
                </div>
            </div>

            <div class="input-group flex-nowrap mb-2">
                <span class="input-group-text text-primary">Instrutor</span>
                <div v-for="prof in this.professores" :key="prof.codigo">
                    <div v-if="prof.codigo == treino.codigo_professor">
                        <input type="text" class="form-control bg-white" v-model="prof.nome" />
                    </div>
                </div>
            </div>

            <div class="input-group flex-nowrap mb-2">
                <span class="input-group-text text-primary">Objetivo</span>
                <input type="text" class="form-control bg-white" v-model="treino.objetivo" />
            </div>

            <div class="input-group flex-nowrap mb-2">
                <span class="input-group-text text-primary">Data de Início</span>
                <input type="text" class="form-control bg-white" v-model="treino.data_inicio" />
            </div>

            <div class="input-group flex-nowrap mb-2">
                <span class="input-group-text text-primary">Duração</span>
                <input type="number" class="form-control bg-white" v-model="treino.duracao"/>
            </div>

            <div class="input-group flex-nowrap mb-2">
                <span class="input-group-text text-primary">Observações</span>
                <input type="text" class="form-control bg-white" v-model="treino.observacoes"/>
            </div>

            
            
            </fieldset>
        </div>
    </div>
</template>

<script>
import axios from "axios";
export default {
    name: 'MostraTreinos',
    props: {
      aluno: Object
    },
    data(){
        return{
            treinos: [],
            professores: [],
            alunos: [],
        }
    },
    methods: {
        refreshData() {
            axios.get("http://localhost:7632/api/Treinos").then((res) => {
                this.treinos = res.data;
            });

            axios.get("http://localhost:7632/api/Professores").then((res) => {
                this.professores = res.data;
            });

            axios.get("http://localhost:7632/api/Alunos").then((res) => {
                this.alunos = res.data;
            });


        },

    },

    mounted: function () {
            this.refreshData();
    },
    

}
</script>