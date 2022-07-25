<template>
    <div class="container-fluid p-4">        

        <h1 class="text-center">Gerenciador de Academia</h1>
        <div class="row mt-4">
            <div class="col-md-7">
                <img src="@/assets/main.jpeg" class="img-fluid rounded" alt="..." style="width:100%;">
            </div>
            <div class="col-md-5">
                <h1 class="text-primary">Bem-Vindo</h1>
                <p style="font-size: 30px;">Através desse software, você pode controlar sua <span class="fw-bold">academia</span>, seus funcionários, alunos e treinos.</p>
                <a href="/login"><button class="btn btn-warning btn-lg mt-2">Comece Já</button></a> 
            </div>
            
        </div>
    </div>
</template>

<script>
export default {
    name: 'MainContent'
}
</script>
