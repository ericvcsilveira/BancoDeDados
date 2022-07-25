<template>
    <div class="container col-8 mb-3 mt-3 border border-danger rounded-3 p-4">
        <h3>Novo Treino</h3>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Objetivo</span>
            <input type="text" class="form-control" v-model="this.objetivo" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Data de Início (a-m-d)</span>
            <input type="text" class="form-control" v-model="this.dataini" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Duração</span>
            <input type="number" class="form-control" v-model="this.duracao"/>
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Observações</span>
            <input type="text" class="form-control" v-model="this.obser"/>
        </div>

        <fieldset disabled>
            <div class="input-group flex-nowrap mb-2">
                <span class="input-group-text">Matrícula Aluno</span>
                <input type="number" class="form-control" v-model="this.aluno.matricula" />
            </div>
        </fieldset>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Código Instrutor</span>
            <select class="form-select" v-model="this.codigo">
                <option class="dropdown-item" v-for="prof in professores" :key="prof.codigo">
                    {{ prof.codigo }} - {{ prof.nome }}
                </option>
            </select>
        </div>

        <button class="btn btn-danger col-12" @click="insereTreino()">Cadastrar</button>
    </div>
</template>

<script>
import axios from "axios";
export default {
  name: "CadastraTreino",
  props: {
      aluno: Object
  },
  data(){
      return {
          treinos: [],
          professores: [],
          objetivo: null,
          dataini: null,
          duracao: null,
          obser: null,
          codigo: null
      }
  },
  methods: {
        refreshData() {
            axios.get("http://localhost:7632/api/Professores").then((res) => {
                this.professores = res.data;
            });

            axios.get("http://localhost:7632/api/Treinos").then((res) => {
                this.treinos = res.data;
            });
        },

        insereTreino(){
            var codigo = this.codigo.split(' ').shift();
            axios
            .post("http://localhost:7632/api/Treinos", {
                objetivo: this.objetivo,
                data_inicio: this.dataini,
                duracao: this.duracao,
                observacoes: this.obser,
                matricula: this.aluno.matricula,
                codigo_professor: codigo
            })
            .then((res) => {
                this.$router.go();
                alert(res.data);
            });
            
        }
    },

    mounted: function () {
        this.refreshData();
    },
};
</script>