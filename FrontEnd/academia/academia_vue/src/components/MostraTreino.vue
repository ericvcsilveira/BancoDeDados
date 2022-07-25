<template>
    <div class="container col-8 mb-3 mt-3 border border-primary rounded-3 p-4">
        <h3>Meus Treinos</h3>

        <div v-for="treino in this.treinos" :key="treino.id">

                <hr>
                <h5 class="text-center mt-2 text-danger">Treino {{treino.id}}</h5>
                
                <fieldset disabled>

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

                
                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text text-primary">Aluno</span>
                    <input type="text" class="form-control bg-white" v-model="treino.aluno" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text text-primary">Professor</span>
                    <input type="text" class="form-control bg-white" v-model="treino.professor" />
                </div>
                </fieldset>
        </div>
    </div>
</template>

<script>
import axios from "axios";
export default {
    name: 'MostraTreino',
    props: {
      mat: Number,
    },
    data(){
        return{
            treinos: [],
        }
    },
    methods: {
        refreshData() {

            console.log("oiii:" , this.mat)
            axios.get("http://localhost:7632/api/TreinosAluno/" + this.mat).then((res) => {
                this.treinos = res.data;
            });
            
        },

    },

    mounted: function () {
            this.refreshData();
    },
    

}
</script>