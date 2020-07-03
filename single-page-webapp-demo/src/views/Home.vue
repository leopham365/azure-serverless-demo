
<template>
  <div>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group id="input-group-applicant" label description>
        <b-container class="container-applicant">
          <b-row>
            <h3>A. Applicant (please PRINT clearly):</h3>
          </b-row>
          <b-row>
            <b-col md="6">
              <b-form-input
                id="input-lastname"
                v-model="form.lastname"
                required
                placeholder="Enter Last Name"
              ></b-form-input>
            </b-col>
            <b-col md="6">
              <b-form-input
                id="input-firstname"
                v-model="form.firstname"
                required
                placeholder="Enter First Name"
              ></b-form-input>
            </b-col>
          </b-row>
          <b-row>
            <b-col md="8">
              <b-form-input
                id="input-email"
                v-model="form.email"
                type="email"
                required
                placeholder="Enter email"
              ></b-form-input>
            </b-col>
            <b-col md="4">
              <b-form-input
                id="input-middleinitial"
                v-model="form.middleinitial"
                placeholder="Enter Middle Initial"
              ></b-form-input>
            </b-col>
          </b-row>
          <b-row>
            <b-col>
              <b-form-datepicker
                id="dateofbirth-datepicker"
                v-model="form.dateofbirth"
                placeholder="Enter Date of Birth"
              ></b-form-datepicker>
            </b-col>
          </b-row>
          <b-row>
            <b-col md="6">
              <b-form-select
                id="input-certification-class"
                v-model="form.certificationClass"
                :options="certificationClasses"
              ></b-form-select>
            </b-col>
            <b-col md="6">
              <b-form-select
                id="input-certification"
                v-model="form.certification"
                :options="certifications"
              ></b-form-select>
            </b-col>
          </b-row>
        </b-container>
      </b-form-group>

      <b-form-group id="input-group-examdetails">
        <b-container class="exam1">
          <b-row>
            <h3>B. Exam Details</h3>
          </b-row>
          <b-row>
            <h5>Examination 1</h5>
          </b-row>
          <b-row>
            <b-col>
              <b-form-select id="input-3" v-model="form.exam1class" :options="classes"></b-form-select>
            </b-col>
            <b-col>
              <b-form-input
                id="input-2"
                v-model="form.exam1AttemptNumber"
                placeholder="Enter Attempt Number"
              ></b-form-input>
            </b-col>
          </b-row>
          <br />
          <h6>1st choice</h6>
          <b-row>
            <b-col>
              <b-form-datepicker
                id="exam1-choice1-requesteddate-datepicker"
                v-model="form.exam1Choice1RequestedDate"
                class="mb-2"
                placeholder="Enter Requested Date"
              ></b-form-datepicker>
            </b-col>
          </b-row>
          <b-row>
            <b-col md="4">
              <b-form-select
                id="input-exam1Choice1Time"
                v-model="form.exam1Choice1Time"
                :options="times"
              ></b-form-select>
            </b-col>
            <b-col md="8">
              <b-form-select
                id="input-exam1Choice1Location"
                v-model="form.exam1Choice1Location"
                :options="locations"
              ></b-form-select>
            </b-col>
          </b-row>
          <b-row>
            <b-col md="12">
              <!-- Styled -->
              <b-form-file
                v-model="form.files"
                multiple
                placeholder="Choose documents or drop them here..."
                drop-placeholder="Drop documents here..."
              ></b-form-file>
            </b-col>
          </b-row>
        </b-container>
      </b-form-group>
      <div>
        <b-button id="submit" type="submit">Submit</b-button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <b-button type="reset">Reset</b-button>
      </div>
    </b-form>
  </div>
</template>

<script>
// @ is an alias to /src
export default {
  data() {
    return {
      form: {
        lastname: "",
        firstname: "",
        middleinitial: "",
        dateofbirth: null,
        email: "",
        certificationClass: null,
        certification: null,
        exam1class: null,
        exam1attemptnumber: null,
        exam1Choice1Location: null,
        exam1Choice1Time: null,
        exam1Choice1RequestedDate: null,
        files: null,
        checked: []
      },
      certificationClasses: [
        { text: "Select the Current Cerficiation Class Held...", value: null },
        {
          text:
            "High Pressure Boilers, Low Pressure Boilers, Thermal Fluid Boilers - Additional charge per 1,000 m2 of heating surface over 2,000 m2 rounded up to the nearest 1,000 m2",
          value: "CB94738F-82A9-EA11-A812-000D3A0C21EB"
        },
        {
          text:
            "High Pressure Boilers, Low Pressure Boilers, Thermal Fluid Boilers(a) up to and including 25 m2 inclusive",
          value: "C194738F-82A9-EA11-A812-000D3A0C21EB"
        },
        {
          text:
            "High Pressure Boilers, Low Pressure Boilers, Thermal Fluid Boilers(d) from 50.1 m2 to 100 m2 inclusive",
          value: "C794738F-82A9-EA11-A812-000D3A0C21EB"
        },
        {
          text:
            "High Pressure Boilers, Low Pressure Boilers, Thermal Fluid Boilers(c) from 100.1 m2 to 500 m2 inclusive",
          value: "C594738F-82A9-EA11-A812-000D3A0C21EB"
        }
      ],
      certifications: [
        { text: "Select A Certification No. ...", value: null },
        {
          text: "Boilers, Pressure Vessels, and Refrigeration",
          value: "75795DB9-84A7-EA11-A812-000D3A0C2A5B"
        },
        {
          text: "Power Engineer",
          value: "77795DB9-84A7-EA11-A812-000D3A0C2A5B"
        },
        {
          text: "Electrical FSR",
          value: "79795DB9-84A7-EA11-A812-000D3A0C2A5B"
        },
        { text: "Gas Fitter", value: "7D795DB9-84A7-EA11-A812-000D3A0C2A5B" },
        {
          text: "Passenger Ropeway Trainer",
          value: "7F795DB9-84A7-EA11-A812-000D3A0C2A5B"
        },
        {
          text: "Pressure Welder",
          value: "E02A0DD4-12A6-EA11-A812-000D3AFF4102"
        }
      ],
      classes: [
        { text: "Please Select A Class...", value: null },
        { text: "1A1", value: "EAAE0753-91A6-EA11-A812-000D3AFF4102" },
        { text: "1A2", value: "A47B915B-91A6-EA11-A812-000D3AFF4102" },
        { text: "4A1", value: "A57B915B-91A6-EA11-A812-000D3AFF4102" },
        { text: "4B1", value: "FDBFF061-91A6-EA11-A812-000D3AFF4102" }
      ],
      locations: [
        { text: "Please Select A Location...", value: null },
        { text: "VICTORIA", value: "A6B8574A-91A6-EA11-A812-000D3AFF4102" },
        {
          text: "VANCOUVER CORPORATE OFFICE",
          value: "A6B8574A-91A6-EA11-A812-000D3AFF4102"
        },
        { text: "CRANBROOK", value: "B129D634-91A6-EA11-A812-000D3AFF4102" },
        { text: "COMOX", value: "73DF5224-91A6-EA11-A812-000D3AFF4102" }
      ],
      times: [
        { text: "Please Select AM / PM...", value: null },
        { text: "AM", value: 557320000 },
        { text: "PM", value: 557320001 }
      ],
      show: true
    };
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      debugger;
      var newExamApp = {
        email: this.form.email,
        lastname: this.form.lastname,
        firstname: this.form.firstname,
        middleinitial: this.form.middleinitial,
        dateofbirth: this.form.dateofbirth,
        certificationClass: this.form.certificationClass,
        certification: this.form.certification,
        exam1class: this.form.exam1class,
        exam1attemptnumber: this.form.exam1attemptnumber,
        exam1Choice1Location: this.form.exam1Choice1Location,
        exam1Choice1Time: this.form.exam1Choice1Time,
        exam1Choice1RequestedDate: this.form.exam1Choice1RequestedDate,
        submittedDocs: []
      };
        
        if(this.form.files !== null){
            let pipeline = new this.$newPipeline(new this.$AnonymousCredential());
            const azureBlobContainerURL = "https://tsbcstorageaccdev.blob.core.windows.net/$web/examApps/" 
                            + this.form.firstname + this.form.lastname + "/";
            
            this.form.files.forEach(file => {
                const blockBlobClient = new this.$BlockBlobClient(azureBlobContainerURL + file.name + sasToken
                    ,  pipeline);
                const resp =    blockBlobClient.uploadBrowserData(file, {
                        maxSingleShotSize: 4 * 1024 * 1024
                    });
                if(resp !== null)
                    console.log(file.name  + ' uploaded')
                let doc = {
                    name: file.name,
                    type: file.type,
                    size: file.size,
                    downloadUrl: portalDownload + file.name
                }
                newExamApp.submittedDocs.push(doc);
            });
        }

      this.$http
        .post( `https://tcbcdevsubmitapplicationforexam.azurewebsites.net/api/SubmitAppForExam`,
          // `http://localhost:7071/api/SubmitAppForExam`, 
          newExamApp
        )
        .then(result => {
          alert(JSON.stringify(result.data));
        });
    },
    onReset(evt) {
      evt.preventDefault();
      // Reset our form values
      this.form.email = "";
      this.form.lastname = "";
      this.form.firstname = "";
      this.form.middleinitial = "";
      this.form.dateofbirth = null;
      this.form.certificationClass = null;
      this.form.certification = null;
      this.form.exam1class = null;
      this.form.exam1attemptnumber = null;
      this.form.exam1Choice1Location = null;
      this.form.exam1Choice1Time = null;
      this.form.exam1Choice1RequestedDate = null;
      debugger;
      this.form.files = null;
      this.form.checked = [];
      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    }
  }
};
</script>

<style lang="scss" scoped>
#submit {
  background: #1498cb !important;
  font-weight: bolder;
}
h5 {
  padding-left: 10px;
}
h6,
label {
  text-align: left;
  padding-left: 5px;
}
.row {
  padding-top: 20px;
}
.example {
  color: red;
}
</style>