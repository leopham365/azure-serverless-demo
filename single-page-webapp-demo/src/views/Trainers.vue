<template>
  <div class="trainers">
    <b-table :items="trainers" :fields="fields" :tbody-tr-class="rowClass"></b-table>
  </div>
</template>

<script >
  export default {
    data() {
        return {
          fields: ['fullName', 'rating', 'address'],
          trainers: []
        }
    },
    mounted: function () {
      var getQuery = { type: "Demo" };
      const getTrainersApi = "https://azureserverlessdemotrainersapi.azurewebsites.net/api/GetTrainers?code=UkXfvEksKAX3mNIPBakaZ9hmJ98IS0tHXssV58pHoqTOsgfaIOuKRQ%3D%3D";
      debugger;
      const that = this;
      this.$http
        .get( getTrainersApi, getQuery)
        .then(result => {
          debugger;
          console.log("Retrieved Trainers: " + JSON.stringify(result.data));
          that._data.trainers = result.data;
        });
    },
    methods: {
      rowClass(item, type) {
        if (!item || type !== 'row') return
        if (item.rating === 5) return 'table-success'
      }
    }
  }
</script>