<template>
  <div class="item-card container">
    <div class="columns">
      <div class="column is-three-quarters has-text-left">
        <BField class="checkbox-field">
          <BCheckbox v-model="done" @input="toggleDone">{{
            content
          }}</BCheckbox>
        
        </BField>
       <div class="edit">
           <BButton  outlined @click="editItem">Edit</BButton>
          </div>
      </div>
    
    </div>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";
import gql from "graphql-tag";
// added mobile responsive styles at the bottom of the code
@Component
export default class ToDoCard extends Vue {
  @Prop({ required: true }) item: any;
  @Prop({ default: () => () => ({}) }) onStatusToggle: Function;

  get content() {
    return this.item.content;
  }

  get createdDate() {
    return this.item.createdDate;
  }

  get createdDateDisplay() {
    return new Date(this.item.createdDate).toUTCString();
  }

  get done() {
    return this.item.status == "DONE";
  }

  set done(val: boolean) {
    this.item.status = val ? "DONE" : "PENDING";
  }

  editItem()
  {
    this.$router.push({
      name: 'edit',
      params: {
        item: this.item,
      }
    })
  }

  toggleDone() {
    this.$apollo
      .mutate({
        mutation: gql`
          mutation($input: UpdateToDoItemInput!) {
            updateToDoItem(input: $input) {
              toDoItem {
                content
                createdDate
                id
                status
              }
            }
          }
        `,
        variables: {
          input: {
            id: this.item.id,
            status: this.item.status
          }
        }
      })
      .then(() => this.onStatusToggle());
  }
}
</script>

<style lang="scss" scoped>
.column {
  line-height: 2.5rem;
  background: #fff;
  padding: 8px 18px;
  margin: 20px;
  justify-content: space-between;
  border: 2px solid black;
  box-shadow: 1px 2px 10px #eee;
  display: flex;
  text-align: center;
}
button.edit {

align-self: flex-end
}
.checkbox-field {
  text-align: center;
}
</style>
