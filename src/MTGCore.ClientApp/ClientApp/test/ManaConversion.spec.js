import Vue from 'vue'
import { shallowMount } from '@vue/test-utils'
import MyComponent from '../src/components/ManaCost.vue'

describe('Basic Mocha String Test', function () {
    it('should return number of charachters in a string', function () {
        assert.equal("Hello".length, 4);
    }); it('should return first charachter of the string', function () {
        assert.equal("Hello".charAt(0), 'H');
    });
});

describe('Counter.vue', () => {
    it('increments count when button is clicked', async () => {
        const wrapper = shallowMount(MyComponent)
    })
});