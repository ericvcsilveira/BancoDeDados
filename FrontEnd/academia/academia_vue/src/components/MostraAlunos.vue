<template>
    <div class="container col-12 mb-3 mt-3 border border-danger rounded-3 p-4">
        <h3>Alunos Cadastrados</h3>

        <div v-for="aluno in this.alunos" :key="aluno.matricula">

            <fieldset disabled>
                <hr>

                <h5 class="text-center mt-4 text-primary">{{ aluno.nome }}</h5>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Matrícula</span>
                    <input type="number" class="form-control" v-model="aluno.matricula"/>
                </div>
                
                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Cpf</span>
                    <input type="number" class="form-control" v-model="aluno.cpf"/>
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Data de nascimento (a-m-d)</span>
                    <input type="text" class="form-control" v-model="aluno.datanasc" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Data de Início (a-m-d)</span>
                    <input type="text" class="form-control" v-model="aluno.dataini" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Email</span>
                    <input type="text" class="form-control" v-model="aluno.email"/>
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Celular</span>
                    <input type="text" class="form-control" v-model="aluno.celular"/>
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Sexo</span>
                    <input type="text" class="form-control" v-model="aluno.sexo" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Cep</span>
                    <input type="number" class="form-control" v-model="aluno.cep" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Rua</span>
                    <input type="text" class="form-control" v-model="aluno.rua" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Número</span>
                    <input type="number" class="form-control" v-model="aluno.numero" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Bairro</span>
                    <input type="text" class="form-control" v-model="aluno.bairro" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Cidade</span>
                    <input type="text" class="form-control" v-model="aluno.cidade" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Estado</span>
                    <input type="text" class="form-control" v-model="aluno.estado" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Unidade da Academia</span>
                    <input type="number" class="form-control" v-model="aluno.codigo_unidade" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Data de contratação (a-m-d)</span>
                    <input type="text" class="form-control" v-model="aluno.data_contratacao" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Código plano</span>
                    <input type="number" class="form-control" v-model="aluno.id_plano" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Código professor</span>
                    <input type="number" class="form-control" v-model="aluno.codigo_professor" />
                </div>

                <div class="input-group flex-nowrap mb-2">
                    <span class="input-group-text">Preço</span>
                    <input type="number" class="form-control" v-model="aluno.preco" />
                </div>

            </fieldset>
        </div>
    </div>
</template>

<script>
import axios from "axios";
export default {
    name: 'MostraAluno',
    data(){
        return{
            alunos: [],
        }
    },
    methods: {
        refreshData() {
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