<template>
  <div class="container p-4">    
    <div class="row mt-3">
      <div class="col-md-6 offset-md-3">
        <LoginAluno />
      </div>
    </div>
  </div>
</template>

<script>
import LoginAluno from "@/components/LoginAluno.vue";
export default {
  name: 'TelaLogin',
  components: {
    LoginAluno,
  }
}
</script>