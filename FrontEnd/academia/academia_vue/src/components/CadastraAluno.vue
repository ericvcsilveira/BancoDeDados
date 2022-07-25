<template>
    <div class="container col-8 mb-3 mt-3 border border-danger rounded-3 p-4">
        <h3>Novo Aluno</h3>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Nome</span>
            <input type="text" class="form-control" v-model="this.nome" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Cpf</span>
            <input type="number" class="form-control" v-model="this.cpf"/>
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Data de nascimento (a-m-d)</span>
            <input type="text" class="form-control" v-model="this.datanasc" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Data de Início (a-m-d)</span>
            <input type="text" class="form-control" v-model="this.dataini" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Email</span>
            <input type="text" class="form-control" v-model="this.email"/>
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Celular</span>
            <input type="text" class="form-control" v-model="this.celular"/>
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Sexo</span>
            <input type="text" class="form-control" v-model="this.sexo" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Cep</span>
            <input type="number" class="form-control" v-model="this.cep" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Rua</span>
            <input type="text" class="form-control" v-model="this.rua" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Número</span>
            <input type="number" class="form-control" v-model="this.numero" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Bairro</span>
            <input type="text" class="form-control" v-model="this.bairro" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Cidade</span>
            <input type="text" class="form-control" v-model="this.cidade" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Estado</span>
            <input type="text" class="form-control" v-model="this.estado" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Unidade da Academia</span>
            <input type="number" class="form-control" v-model="this.unidade" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Data de contratação (a-m-d)</span>
            <input type="text" class="form-control" v-model="this.datacontrato" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Código plano</span>
            <input type="number" class="form-control" v-model="this.plano" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Código professor</span>
            <input type="number" class="form-control" v-model="this.professor" />
        </div>

        <div class="input-group flex-nowrap mb-2">
            <span class="input-group-text">Preço</span>
            <input type="number" class="form-control" v-model="this.preco" />
        </div>



        <button class="btn btn-primary col-md-6 offset-md-3" @click="insereAluno()">Cadastrar</button>
    </div>
</template>

<script>
import axios from "axios";
export default {
  name: "CadastraAluno",
  data(){
      return {
          pontos: 0,
          nome: null,
          cpf: null,
          datanasc: null,
          dataini: null,
          email:null,
          celular: null,
          sexo: null,
          cep: null,
          rua: null,
          numero: null,
          bairro: null,
          cidade: null,
          estado: null,
          unidade: null,
          datacontrato: null,
          plano: null,
          professor: null,
          preco: null,
      }
  },
  methods: {
        insereAluno(){
            axios
            .post("http://localhost:7632/api/Alunos", {
                pontos: 0,
                nome: this.nome,
                cpf: this.cpf,
                datanasc: this.datanasc,
                data_cadastro: this.dataini,
                email:this.email,
                celular: this.celular,
                sexo: this.sexo,
                cep: this.cep,
                rua: this.rua,
                numero: this.numero,
                bairro: this.bairro,
                cidade: this.cidade,
                estado: this.estado,
                codigo_unidade: this.unidade,
                data_contratacao: this.datacontrato,
                id_plano: this.plano,
                codigo_professor: this.professor,
                preco: this.preco
            })
            .then((res) => {
                this.$router.push({path: '/login'})
                alert(res.data);
            });
            
        }
    },

    mounted: function () {
        
    },
};
</script>