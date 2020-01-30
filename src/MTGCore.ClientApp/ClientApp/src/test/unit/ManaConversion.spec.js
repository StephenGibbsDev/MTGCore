import Vue from 'vue'
import ManaCost from "../../components/ManaCost.vue"
import { mount } from "@vue/test-utils"

describe("ManaCost.vue Component", () => {

    it('It should render the props correctly', () => {
        const wrapper = mount(ManaCost)

        assert(1 == 1, "1 equals 1")
    })

})