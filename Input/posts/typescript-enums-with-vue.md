Title: Using typescript enums inside a single file vue component
Published: 11/23/2017
Tags: [vuejs, typescript, quick tips]
---
If you want to use a [typescript enum](https://www.typescriptlang.org/docs/handbook/enums.html) as the backing data source for a select element in vue, you need to include the enum itself in the data of the component.

This would result in code that looks similar to this:
```html
<template>
  <div>
      <select v-model="paymentType">
          <option :value="null">Select Option</option>
          <option :value="PaymentType.CreditCard">Credit Card</option>
          <option :value="PaymentType.Cash">Cash</option>
          <option :value="PaymentType.Check">Check</option>
      </select>
  </div>
</template>
```
```ts
<script>
import Vue from 'vue';

enum PaymentType {
    CreditCard,
    Cash,
    Check
}

export default Vue.extend({
    name: 'PaymentType',
    data () {
        return {
            paymentType: null as PaymentType | null,
            PaymentType: PaymentType
        }
    }
});
</script>
```
