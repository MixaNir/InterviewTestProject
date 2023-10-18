import React, { Component } from 'react';

export class AVGData extends Component {
    static displayName = AVGData.name;
    

    constructor(props) {
        super(props);
        this.state = { dma: [], site: [], dropdown: [], loading: true, dropdownloading: true, evpm: 1 };
    }

    componentDidMount() {
        this.getDropdownInfo();
        this.populateAVGData(this.state.evpm);
    }

    static renderAVGTable(dma, site) {
        return (
            <ul style={{ width: '100%' }}>
                <table className="table table-striped" aria-labelledby="tableLabel" style={{ display: 'inline', marginRight: 100 }}>
                    <thead>
                        <tr>
                            <th>DMA</th>
                            <th>Count</th>
                            <th>CTR</th>
                            <th>EvPM</th>
                        </tr>
                    </thead>
                    <tbody>
                        {dma.map(dma =>
                            <tr key={dma.dma}>
                                <td>{dma.dma}</td>
                                <td>{dma.count}</td>
                                <td>{dma.ctr}</td>
                                <td>{dma.evPM}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                <table className="table table-sm" aria-labelledby="tableLabel" style={{ display: 'inline' }}>
                    <thead>
                        <tr>
                            <th>Site</th>
                            <th>Count</th>
                            <th>CTR</th>
                            <th>EvPM</th>
                        </tr>
                    </thead>
                    <tbody>
                        {site.map(site =>
                            <tr key={site.siteId}>
                                <td>{site.siteId}</td>
                                <td>{site.count}</td>
                                <td>{site.ctr}</td>
                                <td>{site.evPM}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </ul>
        );
    }


    renderDropdown(items) {
        const handleChange = (e) => {
            this.setState({ evpm: e.target.value, loading: true, dma: [], site: [] });
            this.populateAVGData(e.target.value);
        }

        return (
            <div style={{ marginBottom: 20 }} class="dropdown">
                <p style={{ display: 'inline', marginRight: 10 }} >Event type: </p>

                <select id="dropdown" onChange={(e) => handleChange(e)} style={{ display: 'inline'}}>
                    {items.map((item) =>
                        <option value={item.value}>{item.name}</option>
                    )}
                </select>
            </div>
        );
    }

    

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AVGData.renderAVGTable(this.state.dma, this.state.site);

        let dropdown = this.renderDropdown(this.state.dropdown, this.state.evpm);
        return (
            <div>
                <h1 style={{ marginBottom:20 }} id="tableLabel">Agregated Table</h1>
                {dropdown}
                {contents}
            </div>
        );
    }

    async populateAVGData(num) {
        const responseDMA = await fetch('avgtable/getDMAInfo/' + num);
        const responseSite = await fetch('avgtable/getSiteInfo/' + num);
        const dataDMA = await responseDMA.json();
        const dataSite = await responseSite.json();
        this.setState({ dma: dataDMA, site: dataSite, loading: false });
    }

    async getDropdownInfo() {
        const responce = await fetch('additionalInfo/getDropdownTypesInfo');
        const data = await responce.json();
        this.setState({ dropdown: data, dropdownloading: false });
    }
}