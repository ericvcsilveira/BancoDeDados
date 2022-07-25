<template>
  <NavMain />
  <router-view></router-view>
</template>

<script>
import NavMain from "@/components/NavMain.vue";
export default {
  components: {
    NavMain,
  }
}
</script>
