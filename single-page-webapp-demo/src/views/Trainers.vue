<template>
  <div class="about">
    <h1>Trainers</h1>
  </div>
</template>

<script >
  export default {
    mounted: function () {
      var getQuery = { type: "Demo" };
      debugger;
      const getTrainersApi = "<Your_Function_API_URL_n_CODE>";
       // "https://azureserverlessdemotrainersapi.azurewebsites.net/api/GetTrainers?code=UkXfvEksKAX3mNIPBakaZ9hmJ98IS0tHXssV58pHoqTOsgfaIOuKRQ%3D%3D";
      this.$http
        .get( getTrainersApi, getQuery)
        .then(result => {
          alert(JSON.stringify(result.data));
        });
    },
    methods: {
      downloadItem (url) {
          debugger
          // url = "https://tsbcstorageaccdev.z19.web.core.windows.net/examApps/LEOPHAM/ErrorDetails (1).txt"
          this.$http.get(url, { responseType: 'blob' })
          .then(response => {
              const blob = new Blob([response.data], { type: 'application/' + url.split('.').slice(-1) }) //  
              const link = document.createElement('a')
              link.href = URL.createObjectURL(blob)
              link.download = url.split(/[\\/]/).pop()
              link.click()
              URL.revokeObjectURL(link.href)
          })
          .catch(console.error)
      }
    }
  }
</script>