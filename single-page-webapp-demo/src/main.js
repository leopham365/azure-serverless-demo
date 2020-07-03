import "@babel/polyfill";
import "mutationobserver-shim";
import Vue from "vue";
import "./plugins/bootstrap-vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios from "axios"
// import * as AzureIdentity from '@azure/identity'
import {
  BlockBlobClient,
  AnonymousCredential,
  BaseRequestPolicy,
  newPipeline
} from "@azure/storage-blob"

Vue.config.productionTip = false;
Vue.prototype.$http = axios
Vue.prototype.$BlockBlobClient =  BlockBlobClient
Vue.prototype.$AnonymousCredential =  AnonymousCredential
Vue.prototype.$BaseRequestPolicy =  BaseRequestPolicy
Vue.prototype.$newPipeline =  newPipeline
// Vue.prototype.$azureIdentity = AzureIdentity

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
