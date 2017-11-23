Title: Using null as a default value in vue.js data
Published: 11/23/2017
Tags: [vuejs, typescript]
---
While upgrading a project at work to use the [newest typescript typings for vue](https://medium.com/the-vue-point/upcoming-typescript-changes-in-vue-2-5-e9bd7e2ecf08), I ran across an interesting problem.

I had the following component (markup ommited to make the code sample smaller):
```ts
import Vue, { ComponentOptions } from 'vue';

enum PaymentType {
    Check
    CreditCard
    Cash
}

interface AddPayment extends Vue {
    paymentType: PaymentType;
    amount: number;
    checkNumber: string;
    ccNumber: string;
}
export default {
    name: 'AddPayment',
    data () {
        return {
            paymentType: null,
            checkNumber: '',
            ccNumber: '',
            amount: 0,
            PaymentType: PaymentType
        }
    },
    computed: {
        valid() {
            const basic = +this.amount > 0 && this.paymentType !== null;

           switch (this.paymentType) {
				case PaymentType.CreditCard:
					return basic && !!(this.ccNumber || '').trim().length;
				case PaymentType.Check:
					return basic && !!(this.checkNumber || '').trim().length;
				default:
					return basic;
			}
        }
    }
} as ComponentOptions<AddPayment>
```

but once I upgraded to typescript to 2.6.1 and vue to 2.5.8, the compilers first complaint was that `Property 'trim' does not exist on type '(() => any) | ComputedOptions<any>'.` so I removed the `ComponentOptions` and switched from using a plain object to `Vue.extend`

The next thing I needed to do was a type annotation for the return valu eon the computed property.
Then the compiler started telling me `Type 'PaymentType.CreditCard' is not comparable to type 'null'.` and I could not figure out what the issue was.

After some time I realized that since the default value for `this.paymentType` was set to null, so I added type annotions on the data object, with the resulting end code.
```ts
import Vue from 'vue';

enum PaymentType {
    Check
    CreditCard
    Cash
}

export default Vue.extend({
    name: 'AddPayment',
    data () {
        return {
            paymentType: null as PaymentType | null,
            checkNumber: '',
            ccNumber: '',
            amount: 0,
            PaymentType: PaymentType
        }
    },
    computed: {
        valid(): boolean {
            const basic = +this.amount > 0 && this.paymentType !== null;

           switch (this.paymentType) {
				case PaymentType.CreditCard:
					return basic && !!(this.ccNumber || '').trim().length;
				case PaymentType.Check:
					return basic && !!(this.checkNumber || '').trim().length;
				default:
					return basic;
			}
        }
    }
})

```